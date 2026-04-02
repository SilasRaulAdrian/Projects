package ro.axonsoft.eval.minibank.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ro.axonsoft.eval.minibank.model.IdempotentResponse;

@Repository
public interface IdempotencyRepository extends JpaRepository<IdempotentResponse, String> {
}
