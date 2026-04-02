package ro.axonsoft.eval.minibank.config;

import lombok.Getter;
import lombok.Setter;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;
import ro.axonsoft.eval.minibank.model.Currency;

import java.math.BigDecimal;

@Component
@ConfigurationProperties(prefix = "exchange.rates")
@Getter
@Setter
public class ExchangeRateProperties {
    private BigDecimal eur;
    private BigDecimal usd;
    private BigDecimal gbp;
    private BigDecimal ron;

    public BigDecimal getRate(Currency currency) {
        return switch (currency) {
            case RON -> ron;
            case EUR -> eur;
            case USD -> usd;
            case GBP -> gbp;
        };
    }
}
