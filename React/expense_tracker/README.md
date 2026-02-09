# Expense Tracker App

A full-stack expense tracking application that allows users to add, view, and manage expenses through a web interface.

---

## Overview

Expense Tracker App is a full-stack application built with a **React frontend (client)** and a **Node.js (Express) backend**.  
The application helps users track their expenses by storing and retrieving data through a backend API.

The project demonstrates client–server communication, REST APIs, and dynamic data rendering.

---

## How It Works

### Backend
1. The backend is built using Node.js and Express.
2. It exposes API endpoints for managing expenses.
3. Expense data is stored and handled on the server.
4. The backend sends JSON responses to the client.

### Client
1. The client is built using React.
2. The application sends HTTP requests to the backend API.
3. Expenses are fetched and displayed dynamically.
4. User actions update both the backend and the UI.

---

## Features

- Full-stack architecture (client + backend)
- Add and view expenses
- REST API for expense management
- Dynamic expense list rendering
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
   cd expense_tracker/backend
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
   cd expense_tracker/frontend
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
4. Add new expenses through the interface.
5. View and manage stored expenses.

---

## Possible Improvements

- Add user authentication
- Persist expenses using a database
- Add expense categories
- Implement charts and analytics
- Improve error handling
- Deploy the application online
