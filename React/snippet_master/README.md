# Snippet Master App

## Technical Overview

Snippet Master is a **code snippet management web application** built with **React**, designed to showcase frontend skills such as structured state management, form handling, data persistence, and scalable component architecture. The application allows users to store, organize, and quickly access reusable code snippets.

## Functional Scope

* Create, edit, and delete code snippets
* Store snippet title, description, language, and code content
* Organize snippets by category or programming language
* Search and filter snippets
* Persist snippets across sessions (Local Storage or similar)
* Responsive and clean user interface

## Architecture and Design

The application follows a modular, component-based architecture with clear separation between data management and presentation logic.

### Component Breakdown

* `App`

  * Root component
  * Manages global snippet state and persistence logic

* `SnippetList`

  * Renders the list of snippets based on filters/search

* `SnippetItem`

  * Displays a single snippet preview
  * Handles snippet-level actions (edit, delete)

* `SnippetForm`

  * Controlled form for creating and editing snippets

* `Search / Filters`

  * Handles snippet searching and filtering logic

## State Management Strategy

* Application state is managed using React hooks (`useState`, `useEffect`)

* Snippets are stored as structured objects:

  * `id` – unique identifier
  * `title` – snippet name
  * `language` – programming language
  * `code` – code content
  * `metadata` – optional description or tags

* State updates follow immutable patterns for predictable rendering

## Data Flow

* Unidirectional data flow from the root component to child components
* Business logic is centralized to avoid duplicated or inconsistent state
* Child components communicate user actions via callback props

## Persistence Layer

When enabled, the application uses browser storage:

* Initial state is hydrated on application load
* Snippet changes are persisted automatically
* Ensures data is retained across page refreshes

## Error Handling and Edge Cases

* Prevents creation of empty snippets
* Handles empty search results gracefully
* Ensures stable rendering with unique keys

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

* Syntax highlighting for code blocks
* Tag-based organization
* Import/export snippets
* Backend persistence with authentication
* Unit and integration testing
* Improved accessibility

Snippet Master represents a practical example of building a productivity-focused React application with clean architecture and maintainable state management.
