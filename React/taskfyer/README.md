# Taskfyer App

A full-stack task management application that allows users to create, manage, and track tasks through a web interface.

---

## Overview

Taskfyer is a full-stack task management application built with a **React frontend (client)** and a **Node.js (Express) backend**.

The backend handles task data and API requests, while the frontend provides a clean and interactive user interface for managing tasks.  
The project demonstrates client–server communication, REST APIs, and modern frontend development.

---

## How It Works

### Backend
1. The backend is built using **Node.js and Express**.
2. It exposes REST API endpoints for managing tasks.
3. Tasks are stored and managed on the server side.
4. The backend sends JSON responses to the client.

### Client
1. The client is built using **React**.
2. The application sends HTTP requests to the backend API.
3. Tasks are fetched and rendered dynamically in the UI.
4. User actions trigger API requests that update the backend and UI state.

---

## Features

- Full-stack architecture (client + backend)
- Task creation and management
- REST API for task handling
- React-based user interface
- Dynamic task rendering
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
   cd taskfyer/backend
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the backend server:
   ```
   npm start
   ```

The backend will run on `http://localhost:5000` (or the configured port).

### Client Setup

1. Navigate to the client folder:
   ```bash
   cd taskfyer/client
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the React application:
   ```
   npm start
   ```

The client will run on `http://localhost:3000`.

## Usage

1. Start the backend server.
2. Start the client application.
3. Open a browser and go to `http://localhost:3000`.
4. View, manage, and interact with tasks through the UI.
5. All task changes are handled through the backend API.

## Possible Improvements

- Add authentication and user accounts
- Persist tasks using a database
- Implement task completion and priorities
- Improve error handling and validation
- Enhance UI animations and responsiveness
- Deploy the application online
