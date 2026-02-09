# QR Code Generator App

## Technical Overview

This project is a **QR Code Generator** web application built with **React**, created to demonstrate frontend skills such as form handling, third-party library integration, state management, and dynamic UI updates. The application allows users to generate QR codes from text or URLs in real time.

## Functional Scope

* Generate QR codes from user-provided input (text or URL)
* Real-time QR code updates based on input changes
* Input validation and basic error handling
* Download generated QR code as an image (if implemented)
* Clean and responsive user interface

## Architecture and Design

The application uses a simple, component-based architecture focused on clarity and maintainability.

### Component Breakdown

* `App`

  * Root component
  * Manages global state and application layout

* `QrForm`

  * Controlled input form for user data

* `QrPreview`

  * Renders the generated QR code
  * Updates dynamically based on props

## State Management Strategy

* React hooks (`useState`) are used to manage:

  * User input value
  * Generated QR code data

* State updates are synchronous and predictable

* Controlled inputs ensure consistent UI behavior

## QR Code Generation Logic

* Uses a third-party QR code generation library
* QR code is regenerated on each valid input change
* Input data is sanitized before being passed to the generator

## Data Flow

* Unidirectional data flow from `App` to child components
* Business logic is centralized in the root component
* Presentation components remain stateless

## Error Handling and Edge Cases

* Prevents QR generation for empty input
* Handles invalid or unsupported input gracefully
* Ensures UI stability during rapid input changes

## Technologies Used

* **React** – component-based UI development
* **JavaScript / TypeScript** – application logic
* **QR Code library** – QR generation
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

* Support for multiple QR formats (URL, Wi-Fi, contact info)
* Customization options (size, color, error correction level)
* Backend service for QR history
* Unit tests for input validation and logic
* Accessibility improvements

This project represents a concise example of building a utility-focused React application with clean data flow and practical third-party integration.
