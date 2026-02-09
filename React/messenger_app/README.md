# Messenger App

## Technical Overview

This project is a **Messenger / Chat** web application built with **React**, designed to demonstrate frontend skills such as real-time-style UI updates, structured state management, and component-driven architecture. The application focuses on message flow, UI state, and clean separation between logic and presentation.

## Functional Scope

* Display a list of conversations or messages
* Send new messages through a controlled input
* Render messages dynamically in the chat view
* Differentiate messages by sender (user vs recipient)
* Auto-scroll to the latest message (if implemented)
* Responsive chat layout

## Architecture and Design

The application follows a modular React architecture, emphasizing predictable data flow and reusable components.

### Component Breakdown

* `App`

  * Root component
  * Manages global chat state

* `ChatWindow`

  * Displays the active conversation

* `MessageList`

  * Renders the list of messages

* `MessageItem`

  * Represents a single message bubble

* `MessageInput`

  * Controlled input for composing and sending messages

## State Management Strategy

* React hooks (`useState`, `useEffect`) are used for state management

* Messages are stored as structured objects:

  * `id` – unique identifier
  * `text` – message content
  * `sender` – message origin
  * `timestamp` – send time

* State updates are immutable to ensure predictable rendering

## Data Flow

* Unidirectional data flow from the root component to children
* Message creation logic is centralized
* Child components communicate actions via callback props

## UI Behavior and Interaction

* Controlled input ensures reliable message composition
* Conditional rendering is used for message styling
* Optional auto-scroll logic improves user experience

## Error Handling and Edge Cases

* Prevents sending empty messages
* Handles empty conversation state gracefully
* Ensures stable rendering with unique message keys

## Technologies Used

* **React** – component-based UI development
* **JavaScript / TypeScript** – application logic
* **CSS** – layout and chat UI styling

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

* Real-time messaging with WebSockets or Firebase
* User authentication and multiple conversations
* Message persistence with a backend
* Typing indicators and read receipts
* Accessibility improvements

This project represents a clean example of building a chat-style interface in React with a focus on data flow, UI state, and scalability considerations.
