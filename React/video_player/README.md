# Video Player App

## Technical Overview

This project is a **Video Player** web application built with **React**, intended to demonstrate frontend skills such as media handling, component design, state management, and interaction with browser APIs. The application provides custom video playback controls on top of the native HTML5 video element.

## Functional Scope

* Play and pause video playback
* Seek forward and backward using a progress bar
* Display current playback time and total duration
* Volume control and mute functionality
* Fullscreen mode (if implemented)
* Responsive layout adaptable to different screen sizes

## Architecture and Design

The application is structured using reusable React components, separating presentation from media control logic to ensure clarity and maintainability.

### Component Breakdown

* `App`

  * Root component
  * Manages global layout and passes video configuration

* `VideoPlayer`

  * Core component responsible for video rendering
  * Wraps the HTML5 `<video>` element

* `Controls`

  * Custom UI controls (play/pause, seek, volume)
  * Communicates user actions via callbacks

* `ProgressBar`

  * Visualizes playback progress
  * Allows seeking through user interaction

## State Management Strategy

* React hooks (`useState`) are used to track:

  * Play / pause state
  * Current playback time
  * Video duration
  * Volume and mute state

* `useRef` is used to access and control the underlying HTML5 video element without triggering unnecessary re-renders

## Media and Event Handling

* Relies on the **HTML5 Video API** for playback control

* Listens to video events such as:

  * `timeupdate`
  * `loadedmetadata`
  * `ended`

* Ensures synchronization between video state and UI state

## Data Flow

* Unidirectional data flow from parent to child components
* Media state is centralized in the main video component
* UI components remain stateless and receive data via props

## Error Handling and Edge Cases

* Handles unloaded or unsupported video sources
* Prevents invalid seek values
* Ensures UI remains consistent during rapid user interactions

## Technologies Used

* **React** – component-based UI development
* **JavaScript** – application logic
* **HTML5 Video API** – media playback
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

* Keyboard shortcuts for playback control
* Playback speed control
* Subtitle / caption support
* Picture-in-picture mode
* Custom hook for video logic abstraction
* Unit and integration testing

This project serves as an example of integrating browser media APIs into a React application with clean architecture and predictable behavior.
