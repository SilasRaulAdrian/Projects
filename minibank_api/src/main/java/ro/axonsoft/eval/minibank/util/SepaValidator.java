package ro.axonsoft.eval.minibank.util;

import java.util.Set;

public class SepaValidator {
    private static final Set<String> SEPA_COUNTRIES = Set.of(
        "AT", // Austria
        "BE", // Belgium
        "BG", // Bulgaria
        "HR", // Croatia
        "CY", // Cyprus
        "CZ", // Czech Republic
        "DK", // Denmark
        "EE", // Estonia
        "FI", // Finland
        "FR", // France
        "DE", // Germany
        "GR", // Greece
        "HU", // Hungary
        "IE", // Ireland
        "IT", // Italy
        "LV", // Latvia
        "LT", // Lithuania
        "LU", // Luxembourg
        "MT", // Malta
        "NL", // Netherlands
        "PL", // Poland
        "PT", // Portugal
        "RO", // Romania
        "SK", // Slovakia
        "SI", // Slovenia
        "ES", // Spain
        "SE", // Sweden
        "CH", // Switzerland
        "NO", // Norway
        "IS", // Iceland
        "LI", // Liechtenstein
        "SM", // San Marino
        "VA", // Vatican City
        "AD", // Andorra
        "MC", // Monaco
        "GB", // United Kingdom
        "AX"  // Åland Islands
    );

    public static boolean isSepa(String iban) {
        if (iban == null || iban.length() < 2) return false;

        return SEPA_COUNTRIES.contains(iban.substring(0, 2).toUpperCase());
    }
}
