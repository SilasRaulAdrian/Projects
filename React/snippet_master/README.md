# Snippet Master App

A web-based application that allows users to create, store, and manage code snippets in an organized and efficient way.

---

## Overview

Snippet Master is a full-stack application built with a **React frontend (client)** and a **Node.js (Express) backend**.

The application helps users save and manage reusable code snippets, making it easier to organize frequently used code.  
The project demonstrates client–server communication, REST APIs, and modern full-stack web development.

---

## How It Works

### Backend
1. The backend is built using **Node.js and Express**.
2. It exposes REST API endpoints for managing code snippets.
3. Snippets are stored and managed on the server.
4. The backend responds with JSON data to client requests.

### Client
1. The client is built using **React**.
2. The application sends HTTP requests to the backend API.
3. Snippets are fetched, displayed, and managed dynamically.
4. User actions trigger API calls that update snippet data.

---

## Features

- Full-stack architecture (client + backend)
- Create and manage code snippets
- REST API for snippet handling
- React-based user interface
- Dynamic data rendering
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
   cd snippet_master/backend
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
   cd snippet_master/client
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
4. Create, view, and manage code snippets through the interface.
5. All snippet operations are handled through the backend API.

---

## Possible Improvements

- Add user authentication and accounts
- Add syntax highlighting for code snippets
- Organize snippets by language or tags
- Implement search and filtering
- Persist data using a database
- Deploy the application online
