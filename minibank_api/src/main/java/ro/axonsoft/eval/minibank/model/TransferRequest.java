package ro.axonsoft.eval.minibank.model;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Positive;

import java.math.BigDecimal;

public record TransferRequest(@NotBlank String sourceIban,
                              @NotBlank String targetIban,
                              @NotNull @Positive BigDecimal amount,
                              String idempotencyKey) {
}
