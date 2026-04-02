package ro.axonsoft.eval.minibank.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;
import ro.axonsoft.eval.minibank.exception.BusinessRuleException;
import ro.axonsoft.eval.minibank.exception.NotFoundException;
import ro.axonsoft.eval.minibank.model.Responses;

@RestControllerAdvice
public class GlobalExceptionHandler {
    @ExceptionHandler(BusinessRuleException.class)
    public ResponseEntity<Responses.ErrorResponse> handleBusinessRules(BusinessRuleException ex) {
        return ResponseEntity.status(HttpStatus.CONFLICT).body(new Responses.ErrorResponse("REJECTED", ex.getMessage()));
    }

    @ExceptionHandler(NotFoundException.class)
    public ResponseEntity<Responses.ErrorResponse> handleNotFound(NotFoundException ex) {
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Responses.ErrorResponse("REJECTED", ex.getMessage()));
    }

    @ExceptionHandler(MethodArgumentNotValidException.class)
    public ResponseEntity<Responses.ErrorResponse> handleValidation(MethodArgumentNotValidException ex) {
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Responses.ErrorResponse("REJECTED", "Input data is invalid."));
    }
}
