# Expense Tracker App

## Technical Overview

Expense Tracker is a **personal finance tracking web application** built with **React**, designed to demonstrate frontend skills such as state management, data modeling, aggregation logic, and user-driven data visualization. The application allows users to record expenses and analyze spending patterns over time.

## Functional Scope

* Add, edit, and delete expense entries
* Track expenses by amount, category, and date
* Display total expenses and category-based summaries
* Filter expenses by time period or category (if implemented)
* Persist data across sessions (Local Storage or similar)
* Responsive and user-friendly interface

## Architecture and Design

The application follows a clean, component-based architecture with a strong emphasis on predictable data flow and separation of concerns.

### Component Breakdown

* `App`

  * Root component
  * Manages global expense state and persistence

* `ExpenseList`

  * Renders the list of expense entries

* `ExpenseItem`

  * Displays a single expense record

* `ExpenseForm`

  * Controlled form for adding and editing expenses

* `Summary / Charts` (if present)

  * Displays aggregated expense data

## State Management Strategy

* React hooks (`useState`, `useEffect`) are used for state management

* Expenses are stored as structured objects:

  * `id` – unique identifier
  * `amount` – numeric value
  * `category` – expense category
  * `date` – transaction date
  * `description` – optional notes

* State updates follow immutable patterns to ensure predictable rendering

## Data Flow

* Unidirectional data flow from root component to child components
* Aggregation and calculation logic is centralized
* Presentation components remain stateless where possible

## Persistence Layer

When enabled, the application uses browser storage:

* Initial state hydration on application load
* Automatic persistence on expense updates
* Ensures data retention on page refresh

## Error Handling and Edge Cases

* Validates numeric input for expense amounts
* Prevents submission of invalid or empty data
* Handles empty expense lists gracefully

## Technologies Used

* **React** – component-based UI development
* **JavaScript / TypeScript** – application logic
* **CSS** – layout and responsive styling

## Local Development Setup

1. Install dependencies:

   ```bash
   npm install
   ```
2. Start the development server:

   ```bash
   npm start
   ```
3. Open the application at:

   ```
   http://localhost:3000
   ```

## Possible Improvements

* Charts and visual analytics (bar / pie charts)
* Monthly and yearly summaries
* Currency support and formatting
* Backend persistence and authentication
* Export data (CSV)
* Unit and integration testing

Expense Tracker represents a practical example of a data-driven React application with a focus on state management, data aggregation, and maintainable architecture.
