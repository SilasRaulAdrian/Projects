package ro.axonsoft.eval.minibank.model;

import org.springframework.data.domain.Page;

import java.math.BigDecimal;
import java.time.Instant;
import java.util.List;

public class Responses {
    public record ErrorResponse(String status, String message) {}

    public record AccountDto(Long id, String ownerName, String iban,
                             Currency currency, AccountType accountType,
                             BigDecimal balance, Instant createdAt) {}

    public record TransferDto(Long id, String sourceIban, String targetIban,
                              BigDecimal amount, Currency currency,
                              Currency targetCurrency, BigDecimal exchangeRate,
                              BigDecimal convertedAmount, String idempotencyKey,
                              Instant createdAt) {}

    public record TransactionDto(Long id, Long transferId, TransactionType type,
                                 BigDecimal ammount, String counterpartyIban, Instant createdAt) {}

    public record PaginatedResponse<T>(List<T> content, long totalElements,
                                       int totalPages, int number, int size) {
        public static <T> PaginatedResponse<T> from(Page<T> page) {
            return new PaginatedResponse<>(page.getContent(), page.getTotalElements(),
                    page.getTotalPages(), page.getNumber(), page.getSize());
        }
    }
}
