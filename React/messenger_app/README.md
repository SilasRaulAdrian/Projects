# Messenger App

A full-stack messaging application that allows users to communicate with each other through real-time text messages.

---

## Overview

Messenger App is a full-stack chat application built with a **React frontend (client)** and a **Node.js (Express) backend**.

The backend handles message data and API requests, while the frontend provides a real-time messaging interface for users.  
The project demonstrates client–server communication, REST APIs, and the fundamentals of a messaging system.

---

## How It Works

### Backend
1. The backend is built using **Node.js and Express**.
2. It exposes REST API endpoints for sending and retrieving messages.
3. Messages are stored and managed on the server.
4. The backend sends JSON responses to the client.

### Client
1. The client is built using **React**.
2. The application sends HTTP requests to the backend API.
3. Messages are fetched and displayed dynamically in the chat interface.
4. User actions trigger API calls that update messages in real time.

---

## Features

- Full-stack architecture (client + backend)
- Send and receive text messages
- REST API for message handling
- React-based chat interface
- Dynamic message rendering
- Clear separation between frontend and backend

---

## Technologies Used

### Client
- React
- JavaScript (ES6)
- HTML5
- CSS3

### Backend
- Node.js
- Express
- REST API

---

## Installation

### Backend Setup

1. Navigate to the backend folder:
   ```bash
   cd messenger_app/backend
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the backend server:
   ```bash
   npm start
   ```

The backend will run on `http://localhost:5000` (or the configured port).

### Client Setup

1. Navigate to the client folder:
   ```bash
   cd messenger_app/client
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the React application:
   ```bash
   npm start
   ```

The client will run on `http://localhost:3000`.

---

## Usage

1. Start the backend server.
2. Start the client application.
3. Open a browser and go to `http://localhost:3000`.
4. Type a message in the input field.
5. Send the message and view it instantly in the chat interface.

---

## Possible Improvements

- Add user authentication and accounts
- Implement real-time messaging using WebSockets
- Add message timestamps and read status
- Support file and image sharing
- Persist messages using a database
- Deploy the application online
