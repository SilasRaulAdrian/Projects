package ro.axonsoft.eval.minibank.model;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import lombok.Getter;
import lombok.Setter;

@Entity
@Getter
@Setter
public class IdempotentResponse {
    @Id
    private String idempotencyKey;

    private int statusCode;

    @Column(columnDefinition = "TEXT")
    private String responseBody;
}
