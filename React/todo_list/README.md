# Todo List App

## Technical Overview

This project is a **Todo List** web application built with **React**, intended to demonstrate solid frontend fundamentals. The focus is on clean component design, predictable state management, and clear data flow rather than visual complexity.

## Functional Scope

* Full CRUD operations on todo items
* Task completion toggling
* Task filtering by status (all / active / completed)
* Controlled inputs for form handling
* Optional persistence using browser Local Storage

## Architecture and Design

The application is structured using a component-based architecture, following React best practices and separation of concerns.

### Component Breakdown

* `App`

  * Root component
  * Owns the global todo state
  * Handles persistence and filtering logic

* `TodoList`

  * Receives filtered todos as props
  * Responsible only for rendering the list

* `TodoItem`

  * Stateless or minimally stateful component
  * Handles user interactions (toggle, delete, edit trigger)

* `TodoForm`

  * Controlled form component
  * Manages input state and validation

* `Filters`

  * UI-only component
  * Triggers state changes via callbacks

## State Management Strategy

* Global state is managed using React hooks (`useState`)

* Side effects such as data persistence are handled with `useEffect`

* Todos are stored as an array of objects:

  * `id` – unique identifier
  * `title` – task description
  * `completed` – boolean status

* All state updates are immutable to ensure predictable re-rendering

## Data Flow

* Unidirectional data flow from `App` to child components via props
* State mutations occur only in the root component
* Child components communicate actions upward through callback props

## Persistence Layer

When enabled, the application uses **Local Storage**:

* Initial state is hydrated on application mount
* State changes trigger storage updates
* Prevents data loss on page refresh

## Error Handling and Edge Cases

* Prevents submission of empty tasks
* Ensures stable rendering with unique keys
* Handles empty todo list gracefully

## Technologies Used

* **React** (functional components)
* **JavaScript / TypeScript**
* **CSS** for layout and responsiveness

## Local Setup

1. Install dependencies:

   ```bash
   npm install
   ```
2. Start development server:

   ```bash
   npm start
   ```
3. Open in browser:

   ```
   http://localhost:3000
   ```

## Possible Improvements

* Replace `useState` with `useReducer` for more complex logic
* Introduce Context API to reduce prop drilling
* Add unit tests (Jest, React Testing Library)
* Add backend persistence and authentication
* Improve accessibility (ARIA, keyboard navigation)

This project represents a clean example of a small but well-structured React application.
