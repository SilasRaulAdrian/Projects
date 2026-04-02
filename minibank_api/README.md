# MiniBank API

A lightweight Spring Boot REST API simulating core banking operations: account management, fund transfers with currency conversion, and transaction history.

---

## Tech Stack

- **Java 21** + **Spring Boot 3**
- **Spring Data JPA** + **H2** (in-memory database)
- **Hibernate 7**
- **Lombok**
- **Jakarta Validation**
- **Apache Commons Validator** (IBAN validation)

---

## Getting Started

### Prerequisites

- Java 21+
- Maven 3.8+

### Run

```bash
mvn spring-boot:run
```

The API will be available at `http://localhost:8080`.

### Configuration

Set exchange rates in `application.properties`:

```properties
exchange.rates.eur=4.97
exchange.rates.usd=4.60
exchange.rates.gbp=5.80
exchange.rates.ron=1.00
```

---

## How It Works

### System Account

On startup, a **system account** is automatically seeded with ID `1` and IBAN `RO49AAAA1B31007593840000`. This account acts as the bank itself — it is used for deposits (bank → customer) and withdrawals (customer → bank). Its balance is never checked for sufficiency and is never actually modified.

### Transfers

When a transfer is processed:

1. Both source and target IBANs are validated as SEPA-compliant.
2. Source and target accounts are locked with a **pessimistic write lock** (deadlock-safe: IBANs are sorted before locking).
3. If currencies differ, the amount is converted using the configured exchange rates (via RON as the pivot currency).
4. For **SAVINGS accounts**, a daily transfer limit of **5,000 EUR equivalent** is enforced.
5. Balances are updated and a `Transfer` record is saved.
6. One or two `Transaction` records are created depending on whether the system account is involved.

### Idempotency

Any transfer request that includes an `idempotencyKey` is cached after execution. Repeating the same request with the same key returns the original response without re-processing.

### Currency Conversion

All rates are stored relative to RON. To convert from currency A to currency B:

```
exchangeRate = rate(A) / rate(B)
convertedAmount = amount × exchangeRate
```

---

## API Reference

### Accounts

#### `POST /api/accounts`

Create a new bank account.

**Request body:**

```json
{
  "ownerName": "John Doe",
  "iban": "RO91BRDE360SV54748603600",
  "currency": "RON",
  "accountType": "CHECKING"
}
```

**Responses:**

- `201 Created` — account created successfully
- `400 Bad Request` — invalid IBAN format
- `409 Conflict` — IBAN already in use

---

#### `GET /api/accounts/{accountId}`

Get a single account by ID.

**Responses:**

- `200 OK`
- `404 Not Found`

---

#### `GET /api/accounts?page=0&size=10`

List all accounts (paginated).

---

#### `GET /api/accounts/{accountId}/transactions?page=0&size=10`

Get transaction history for a specific account, ordered by date descending.

**Responses:**

- `200 OK`
- `404 Not Found` — account does not exist

---

### Transfers

#### `POST /api/transfers`

Initiate a fund transfer between two accounts.

**Request body:**

```json
{
  "sourceIban": "RO49AAAA1B31007593840000",
  "targetIban": "RO91BRDE360SV54748603600",
  "amount": 500.0,
  "idempotencyKey": "txn-abc-001"
}
```

- `idempotencyKey` is optional but recommended.
- Both IBANs must be valid SEPA IBANs.
- Source and target must be different.

**Responses:**

- `201 Created` — transfer processed
- `404 Not Found` — source or target account not found
- `409 Conflict` — insufficient funds or savings daily limit exceeded

---

#### `GET /api/transfers/{transferId}`

Get a single transfer by ID.

---

#### `GET /api/transfers?iban=...&fromDate=...&toDate=...&page=0&size=10`

List transfers with optional filters.

| Parameter  | Type      | Description                                     |
| ---------- | --------- | ----------------------------------------------- |
| `iban`     | `String`  | Filter by source or target IBAN                 |
| `fromDate` | `Instant` | ISO 8601 datetime (e.g. `2026-01-01T00:00:00Z`) |
| `toDate`   | `Instant` | ISO 8601 datetime                               |
| `page`     | `int`     | Page number (default: 0)                        |
| `size`     | `int`     | Page size (default: 10)                         |

---

### Exchange Rates

#### `GET /api/exchange-rate`

Returns all configured exchange rates relative to RON.

**Response:**

```json
{
  "EUR": 4.97,
  "USD": 4.6,
  "RON": 1.0,
  "GBP": 5.8
}
```

---

## Business Rules

| Rule                | Details                                                                         |
| ------------------- | ------------------------------------------------------------------------------- |
| SEPA validation     | Both IBANs must belong to a SEPA country                                        |
| Same account        | Source and target cannot be the same account                                    |
| Sufficient funds    | Source balance must cover the transfer amount (unless source is system account) |
| Savings daily limit | Max 5,000 EUR equivalent per day for SAVINGS accounts                           |
| Currency conversion | Automatically applied when source and target currencies differ                  |
| Idempotency         | Same `idempotencyKey` always returns the same response                          |

---

## Supported Currencies

`RON`, `EUR`, `USD`, `GBP`

---

## Supported Account Types

| Type       | Description                                           |
| ---------- | ----------------------------------------------------- |
| `CHECKING` | Standard account, no transfer limits                  |
| `SAVINGS`  | Daily outgoing transfer limit of 5,000 EUR equivalent |
