# Authentication App

A full-stack authentication application that allows users to register, log in, and manage access to protected content.

---

## Overview

Authentication App is a full-stack web application built with a **React frontend (client)** and a **Node.js (Express) backend**.  
The application demonstrates user authentication concepts such as registration, login, and protected routes.

The project focuses on client–server communication, authentication flow, and secure user access handling.

---

## How It Works

### Backend
1. The backend is built using Node.js and Express.
2. It exposes API endpoints for user registration and login.
3. User credentials are validated on the server.
4. Authentication responses are sent to the client.

### Client
1. The client is built using React.
2. Users can register and log in through forms.
3. The client sends authentication requests to the backend.
4. Authenticated users can access protected parts of the application.

---

## Features

- Full-stack architecture (client + backend)
- User registration and login
- Authentication API endpoints
- Protected access flow
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
   cd authentication_app/backend
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
   cd authentication_app/auth-kit-client
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
4. Register a new user account.
5. Log in using the created credentials.
6. Access protected sections of the application.

---

## Possible Improvements

- Add password hashing and security enhancements
- Implement JWT-based authentication
- Add logout functionality
- Add user roles and permissions
- Persist users using a database
- Deploy the application online
