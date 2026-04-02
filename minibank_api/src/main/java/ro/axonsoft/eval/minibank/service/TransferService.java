package ro.axonsoft.eval.minibank.service;

import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import ro.axonsoft.eval.minibank.config.ExchangeRateProperties;
import ro.axonsoft.eval.minibank.exception.BusinessRuleException;
import ro.axonsoft.eval.minibank.exception.NotFoundException;
import ro.axonsoft.eval.minibank.model.*;
import ro.axonsoft.eval.minibank.repository.AccountRepository;
import ro.axonsoft.eval.minibank.repository.TransactionRepository;
import ro.axonsoft.eval.minibank.repository.TransferRepository;
import ro.axonsoft.eval.minibank.util.SepaValidator;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.time.Instant;
import java.time.LocalDate;
import java.time.ZoneId;
import java.util.List;
import java.util.Objects;
import java.util.stream.Stream;

@Service
@RequiredArgsConstructor
public class TransferService {
    private final AccountRepository accountRepository;
    private final TransferRepository transferRepository;
    private final TransactionRepository transactionRepository;
    private final ExchangeRateProperties rates;

    @Transactional
    public Transfer processTransfer(TransferRequest request) {
        if (!SepaValidator.isSepa(request.sourceIban()) || !SepaValidator.isSepa(request.targetIban())) {
            throw new BusinessRuleException("Both source and target IBANs must be valid SEPA IBANs.");
        }

        if (request.sourceIban().equals(request.targetIban())) {
            throw new BusinessRuleException("Account source and target must be different.");
        }

        List<String> ibans = Stream.of(request.sourceIban(), request.targetIban()).sorted().toList();
        List<Account> accounts = accountRepository.findByIbanInForUpdate(ibans);

        Account source = accounts.stream().filter(a -> a.getIban().equals(request.sourceIban())).findFirst().orElseThrow(
                () -> new NotFoundException("Source account not found."));
        Account target = accounts.stream().filter(a -> a.getIban().equals(request.targetIban())).findFirst().orElseThrow(
                () -> new NotFoundException("Target account not found."));

        boolean isSourceSystem = source.getId().equals(1L);
        boolean isTargetSystem = target.getId().equals(1L);

        if (!isSourceSystem && source.getBalance().compareTo(request.amount()) < 0) {
            throw new BusinessRuleException("Insufficient funds.");
        }

        BigDecimal convertedAmount;
        BigDecimal exchangeRate = null;

        if (source.getCurrency() == target.getCurrency()) {
            convertedAmount = request.amount();
        } else {
            BigDecimal sourceToRon = rates.getRate(source.getCurrency());
            BigDecimal targetToRon = rates.getRate(target.getCurrency());
            exchangeRate = sourceToRon.divide(targetToRon, 6, RoundingMode.HALF_EVEN);
            convertedAmount = request.amount().multiply(exchangeRate).setScale(2, RoundingMode.HALF_EVEN);
        }

        if (source.getType() == AccountType.SAVINGS) {
            checkSavingsLimit(source, request.amount());
        }

        if (!isSourceSystem) {
            source.setBalance(source.getBalance().subtract(request.amount()));
        }

        if (!isTargetSystem) {
            target.setBalance(target.getBalance().add(convertedAmount));
        }

        accountRepository.save(source);
        accountRepository.save(target);

        Transfer transfer = new Transfer();
        transfer.setSourceAccount(source);
        transfer.setAmount(request.amount());
        transfer.setTargetAccount(target);
        transfer.setCurrency(source.getCurrency());
        transfer.setTargetCurrency(target.getCurrency());
        transfer.setExchangeRate(exchangeRate);
        transfer.setConvertedAmount(!Objects.equals(convertedAmount, request.amount()) ? convertedAmount : null);
        transfer.setIdempotencyKey(request.idempotencyKey());
        transfer = transferRepository.save(transfer);

        if (isSourceSystem) {
            Transaction targetTransaction = new Transaction();
            targetTransaction.setAccount(target);
            targetTransaction.setTransfer(transfer);
            targetTransaction.setType(TransactionType.DEPOSIT);
            targetTransaction.setAmount(convertedAmount);
            targetTransaction.setCounterpartyIban(null);
            targetTransaction.setCreatedAt(transfer.getCreatedAt());
            transactionRepository.save(targetTransaction);
        } else if (isTargetSystem) {
            Transaction sourceTransaction = new Transaction();
            sourceTransaction.setAccount(source);
            sourceTransaction.setTransfer(transfer);
            sourceTransaction.setType(TransactionType.WITHDRAWAL);
            sourceTransaction.setAmount(request.amount());
            sourceTransaction.setCounterpartyIban(null);
            sourceTransaction.setCreatedAt(transfer.getCreatedAt());
            transactionRepository.save(sourceTransaction);
        } else {
            Transaction sourceTransaction = new Transaction();
            sourceTransaction.setAccount(source);
            sourceTransaction.setTransfer(transfer);
            sourceTransaction.setType(TransactionType.TRANSFER_OUT);
            sourceTransaction.setAmount(request.amount());
            sourceTransaction.setCounterpartyIban(target.getIban());
            sourceTransaction.setCreatedAt(transfer.getCreatedAt());
            transactionRepository.save(sourceTransaction);

            Transaction targetTransaction = new Transaction();
            targetTransaction.setAccount(target);
            targetTransaction.setTransfer(transfer);
            targetTransaction.setType(TransactionType.TRANSFER_IN);
            targetTransaction.setAmount(convertedAmount);
            targetTransaction.setCounterpartyIban(source.getIban());
            targetTransaction.setCreatedAt(transfer.getCreatedAt());
            transactionRepository.save(targetTransaction);
        }

        return transfer;
    }

    private void checkSavingsLimit(Account source, BigDecimal amount) {
        LocalDate today = LocalDate.now(ZoneId.of("UTC"));
        Instant startOfDay = today.atStartOfDay(ZoneId.of("UTC")).toInstant();
        Instant endOfDay = today.plusDays(1).atStartOfDay(ZoneId.of("UTC")).toInstant();

        List<Transfer> todayTransfers = transferRepository.findTodayTransfersBySourceAccount(source, startOfDay, endOfDay);
        BigDecimal eurToRon = rates.getRate(Currency.EUR);
        BigDecimal cumulativeEur = BigDecimal.ZERO;

        for (Transfer t : todayTransfers) {
            BigDecimal tRateToRon = rates.getRate(t.getCurrency());
            BigDecimal tEurEquivalent = t.getAmount().multiply(tRateToRon).divide(eurToRon, 2, RoundingMode.HALF_EVEN);
            cumulativeEur = cumulativeEur.add(tEurEquivalent);
        }

        BigDecimal currentRateToRon = rates.getRate(source.getCurrency());
        BigDecimal currentEurEquivalent = amount.multiply(currentRateToRon).divide(eurToRon, 2, RoundingMode.HALF_EVEN);

        if (cumulativeEur.add(currentEurEquivalent).compareTo(new BigDecimal("5000.00")) > 0) {
            throw new BusinessRuleException("Daily transfer limit of 5000 EUR exceeded for savings account.");
        }
    }
}
