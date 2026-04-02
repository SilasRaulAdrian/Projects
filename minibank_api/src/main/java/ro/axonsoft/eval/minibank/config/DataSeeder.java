package ro.axonsoft.eval.minibank.config;

import lombok.RequiredArgsConstructor;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import ro.axonsoft.eval.minibank.model.Account;
import ro.axonsoft.eval.minibank.model.AccountType;
import ro.axonsoft.eval.minibank.model.Currency;
import ro.axonsoft.eval.minibank.repository.AccountRepository;

import java.math.BigDecimal;
import java.time.Instant;

@Component
@RequiredArgsConstructor
public class DataSeeder implements CommandLineRunner {
    private final AccountRepository accountRepository;

    @Override
    public void run(String... args) {
        if (accountRepository.findById(1L).isEmpty()) {
            Account systemAccount = new Account();
            systemAccount.setOwnerName("System Bank");
            systemAccount.setIban("RO49AAAA1B31007593840000");
            systemAccount.setType(AccountType.CHECKING);
            systemAccount.setCurrency(Currency.RON);
            systemAccount.setBalance(new BigDecimal("999999999.00"));
            systemAccount.setCreatedAt(Instant.now());
            accountRepository.save(systemAccount);
        }
    }
}
