package ro.axonsoft.eval.minibank.model;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;

public record AccountRequest(@NotBlank String ownerName,
                             @NotBlank String iban,
                             @NotNull Currency currency,
                             @NotNull AccountType accountType) {
}
