# Simple Finance Dashboard

A **Streamlit** web app for visualizing and categorizing personal bank transactions. Upload a CSV export from your bank, assign categories to your expenses, and instantly see where your money is going — with persistent category rules that apply automatically on future uploads.

---

## How It Works

The app reads a CSV file of bank transactions, splits them into **debits (expenses)** and **credits (payments)**, and automatically categorizes each transaction based on keyword rules you define. Categories and their keywords are saved locally to a `categories.json` file, so your rules persist between sessions.

### Flow

```
Upload transaction CSV
        ↓
Parse & clean data (amounts, dates, column names)
        ↓
Auto-categorize rows by matching transaction details to saved keywords
        ↓
Display editable table — reassign categories manually if needed
        ↓
Click "Apply Changes" → new keyword rules saved to categories.json
        ↓
Pie chart + summary table show spending by category
```

---

## Features

- **Auto-categorization** — transactions are matched against saved keyword rules automatically on every upload
- **Persistent categories** — category rules are stored in `categories.json` and reloaded on the next session
- **Inline editing** — reassign categories directly in the table using a dropdown; no external tools needed
- **Learning system** — when you reassign a transaction, its details are saved as a keyword for that category, improving future auto-categorization
- **Expense summary** — sortable table and pie chart breaking down spending by category
- **Payments tab** — separate view for incoming credits with a total summary

---

## Requirements

- Python 3.9+

### Install dependencies

```bash
pip install streamlit pandas plotly
```

---

## CSV Format

The app expects a CSV file with at least the following columns:

| Column         | Format                     | Example            |
| -------------- | -------------------------- | ------------------ |
| `Date`         | `DD Mon YYYY`              | `15 Jan 2024`      |
| `Details`      | Transaction description    | `CARREFOUR MARKET` |
| `Amount`       | Number (commas allowed)    | `1,250.00`         |
| `Debit/Credit` | Either `Debit` or `Credit` | `Debit`            |

> Amounts are displayed in **AED** — update the format string in `app.py` if your currency differs.

---

## Usage

Start the app:

```bash
streamlit run app.py
```

Your browser will open at `http://localhost:8501`.

### Workflow

1. **Upload** your bank transaction CSV file
2. Go to the **Expenses (Debits)** tab to see your spending
3. **Add a new category** using the text input (e.g. `Groceries`, `Transport`)
4. **Reassign categories** in the table by selecting from the dropdown
5. Click **Apply Changes** — the transaction's details are saved as a keyword for that category
6. View the **Expense Summary** table and pie chart
7. Switch to **Payments (Credits)** to see incoming transactions and total

---

## Project Structure

```
.
├── app.py              # Main Streamlit application
├── categories.json     # Auto-generated — stores your category keyword rules
└── README.md           # This file
```

---

## Notes

- `categories.json` is created automatically on first use and updated every time you apply changes. Do not delete it if you want to keep your category rules.
- Keyword matching is **case-insensitive** and based on exact match of the full `Details` field.
- The app defaults to `Uncategorized` for any transaction that doesn't match a known keyword.
- To reset all categories, delete `categories.json` and restart the app.
- Currency format is hardcoded to **AED** — change `"%.2f AED"` in `app.py` to match your local currency.
