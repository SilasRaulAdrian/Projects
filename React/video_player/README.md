# Video Player App

A full-stack video player application that allows users to upload, stream, and watch videos through a web interface.

---

## Overview

This project is a full-stack video player built with a **React frontend** and a **Node.js (Express) backend**.

The backend handles video storage and streaming, while the frontend provides a user-friendly interface for browsing and playing videos.  
The project demonstrates client–server communication, REST APIs, video streaming, and modern frontend development.

---

## How It Works

### Backend
1. The backend is built using **Node.js and Express**.
2. Videos are stored in the `public/videos` directory on the server.
3. A REST API endpoint provides access to the available videos.
4. Video files are streamed directly from the server to the client.

### Frontend
1. The frontend is built with **React**.
2. The application fetches the list of available videos from the backend API.
3. Users can:
   - View a list of uploaded videos
   - Select a video
   - Play the video using a custom video player component
4. Video playback is handled using the HTML5 `<video>` element.

---

## Features

- Video streaming from a backend server
- React-based user interface
- Upload and list available videos
- Custom video player component
- REST API for video handling
- Separation between frontend and backend

---

## Technologies Used

### Frontend
- React
- JavaScript (ES6)
- HTML5
- CSS

### Backend
- Node.js
- Express
- REST API
- UUID (for unique video names)

---

## Installation

### Backend Setup

1. Navigate to the backend folder:
   ```bash
   cd video_player/backend
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

### Frontend Setup

1. Navigate to the frontend folder:
   ```bash
   cd video_player/frontend-app
   ```
   
2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the React application:
   ```
   npm start
   ```

The frontend will run on `http://localhost:3000`.

## Usage

1. Start the backend server.
2. Start the frontend React application.
3. Open a browser and go to `http://localhost:3000`.
4. Browse the available videos.
5. Select a video to play it directly in the browser.

## Possible Improvements

- Add authentication for video uploads
- Implement video deletion and management
- Add video thumbnails
- Improve video buffering and loading indicators
- Add comments or likes for videos
- Deploy the application online
