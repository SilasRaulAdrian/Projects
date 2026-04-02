package ro.axonsoft.eval.minibank.controller;

import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.apache.commons.validator.routines.IBANValidator;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import ro.axonsoft.eval.minibank.config.ExchangeRateProperties;
import ro.axonsoft.eval.minibank.exception.NotFoundException;
import ro.axonsoft.eval.minibank.model.*;
import ro.axonsoft.eval.minibank.model.Responses.*;
import ro.axonsoft.eval.minibank.repository.AccountRepository;
import ro.axonsoft.eval.minibank.repository.IdempotencyRepository;
import ro.axonsoft.eval.minibank.repository.TransactionRepository;
import ro.axonsoft.eval.minibank.repository.TransferRepository;
import ro.axonsoft.eval.minibank.service.TransferService;
import tools.jackson.databind.ObjectMapper;

import java.math.BigDecimal;
import java.time.Instant;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class BankController {
    private final TransferService transferService;
    private final AccountRepository accountRepository;
    private final TransferRepository transferRepository;
    private final TransactionRepository transactionRepository;
    private final IdempotencyRepository idempotencyRepository;
    private final ExchangeRateProperties rates;
    private final ObjectMapper objectMapper;

    private AccountDto mapToAccountDto(Account a) {
        return new AccountDto(a.getId(),
                a.getOwnerName(), a.getIban(),
                a.getCurrency(), a.getType(),
                a.getBalance(), a.getCreatedAt());
    }

    private TransferDto mapToTransferDto(Transfer t) {
        return new TransferDto(t.getId(), t.getSourceAccount().getIban(),
                t.getTargetAccount().getIban(), t.getAmount(),
                t.getCurrency(), t.getTargetCurrency(), t.getExchangeRate(),
                t.getConvertedAmount(), t.getIdempotencyKey(), t.getCreatedAt());
    }

    // 1. POST /api/accounts
    @PostMapping("/accounts")
    public ResponseEntity<?> createAccount(@Valid @RequestBody AccountRequest request) {
        if (!IBANValidator.getInstance().isValid(request.iban())) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new ErrorResponse("REJECTED", "IBAN invalid."));
        }
        if (accountRepository.findByIban(request.iban()).isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).body(new ErrorResponse("REJECTED", "IBAN in use."));
        }

        Account account = new Account();
        account.setOwnerName(request.ownerName());
        account.setIban(request.iban());
        account.setType(request.accountType());
        account.setCurrency(request.currency());
        account.setBalance(BigDecimal.ZERO);
        account = accountRepository.save(account);

        return ResponseEntity.status(HttpStatus.CREATED).body(mapToAccountDto(account));
    }

    // 2. GET /api/accounts/{accountId}
    @GetMapping("/accounts/{accountId}")
    public ResponseEntity<?> getAccount(@PathVariable Long accountId) {
        Optional<Account> accountOpt = accountRepository.findById(accountId);

        if (accountOpt.isPresent()) {
            return ResponseEntity.ok(mapToAccountDto(accountOpt.get()));
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND)
                    .body(new ErrorResponse("REJECTED", "Not found."));
        }
    }

    // 3. GET /api/accounts
    @GetMapping("/accounts")
    public ResponseEntity<?> listAccounts(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "10") int size) {
        Page<AccountDto> accountsPage = accountRepository.findAll(PageRequest.of(page, size)).map(this::mapToAccountDto);
        return ResponseEntity.ok(PaginatedResponse.from(accountsPage));
    }

    // 4. POST /api/transfers
    @PostMapping("/transfers")
    public ResponseEntity<?> createTransfer(@Valid @RequestBody TransferRequest request) {
        String key = request.idempotencyKey();
        if (key != null) {
            Optional<IdempotentResponse> cached = idempotencyRepository.findById(key);
            if (cached.isPresent()) {
                return ResponseEntity.status(cached.get().getStatusCode()).contentType(MediaType.APPLICATION_JSON).body(cached.get().getResponseBody());
            }
        }

        try {
            Transfer transfer = transferService.processTransfer(request);
            ResponseEntity<?> response = ResponseEntity.status(HttpStatus.CREATED).body(mapToTransferDto(transfer));
            cacheResponse(key, response);
            return response;
        } catch (RuntimeException ex) {
            HttpStatus status = ex instanceof NotFoundException ? HttpStatus.NOT_FOUND : HttpStatus.CONFLICT;
            ResponseEntity<?> response = ResponseEntity.status(status).body(new ErrorResponse("REJECTED", ex.getMessage()));
            cacheResponse(key, response);
            throw ex;
        }
    }

    // 5. GET /api/transfers/{transferId}
    @GetMapping("/transfers/{transferId}")
    public ResponseEntity<?> getTransfer(@PathVariable Long transferId) {
        Optional<Transfer> transferOpt = transferRepository.findById(transferId);

        if (transferOpt.isPresent()) {
            return ResponseEntity.ok(mapToTransferDto(transferOpt.get()));
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND)
                    .body(new ErrorResponse("REJECTED", "Not found."));
        }
    }

    // 6. GET /api/transfers
    @GetMapping("/transfers")
    public ResponseEntity<?> listTransfers(
            @RequestParam(required = false) String iban,
            @RequestParam(required = false) @DateTimeFormat(iso = DateTimeFormat.ISO.DATE_TIME) Instant fromDate,
            @RequestParam(required = false) @DateTimeFormat(iso = DateTimeFormat.ISO.DATE_TIME) Instant toDate,
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "10") int size) {
        Page<TransferDto> trasfersPage = transferRepository.findWithFilters(iban, fromDate, toDate, PageRequest.of(page, size)).map(this::mapToTransferDto);
        return ResponseEntity.ok(PaginatedResponse.from(trasfersPage));
    }

    // 7. GET /api/accounts/{accountId}/transactions
    @GetMapping("/accounts/{accountId}/transactions")
    public ResponseEntity<?> getTransactions(
            @PathVariable("accountId") Long accountId,
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "10") int size) {
        if (!accountRepository.existsById(accountId)) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new ErrorResponse("REJECTED", "Account not found."));
        }
        Page<TransactionDto> txPage = transactionRepository.findByAccountIdOrderByCreatedAtDesc(
                accountId, PageRequest.of(page, size)).map(t -> new TransactionDto(
                        t.getId(), t.getTransfer().getId(), t.getType(), t.getAmount(),
                        t.getCounterpartyIban(), t.getCreatedAt())
                );
        return ResponseEntity.ok(PaginatedResponse.from(txPage));
    }

    // 8. GET /api/exchange-rates
    @GetMapping("/exchange-rates")
    public ResponseEntity<?> getExchangeRates() {
        Map<String, BigDecimal> ratesMap = new LinkedHashMap<>();
        ratesMap.put("EUR", rates.getRate(Currency.EUR));
        ratesMap.put("USD", rates.getRate(Currency.USD));
        ratesMap.put("RON", rates.getRate(Currency.RON));
        ratesMap.put("GBP", rates.getRate(Currency.GBP));
        return ResponseEntity.ok(ratesMap);
    }

    private void cacheResponse(String key, ResponseEntity<?> responseEntity) {
        if (key == null || key.isBlank()) return;

        try {
            IdempotentResponse cached = new IdempotentResponse();
            cached.setIdempotencyKey(key);
            cached.setStatusCode(responseEntity.getStatusCode().value());
            cached.setResponseBody(objectMapper.writeValueAsString(responseEntity.getBody()));
            idempotencyRepository.save(cached);
        } catch (Exception ignored) {}
    }
}
