# Vapi AI Voice Assistant

A web application that conducts AI-powered voice screening calls with candidates/leads. The user fills in their contact details, starts a live voice call with an AI assistant powered by **Vapi**, and after the call ends receives a structured summary and qualification result.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [How It Works](#how-it-works)
  - [Contact Form](#contact-form)
  - [Starting the Call](#starting-the-call)
  - [During the Call](#during-the-call)
  - [After the Call](#after-the-call)
- [Setup & Installation](#setup--installation)
- [Environment Variables](#environment-variables)
- [Running the App](#running-the-app)
- [API Reference](#api-reference)

---

## Overview

The app walks a user through a voice-based interview/screening flow:

1. User enters their **first name, last name, email, and phone number**
2. An AI assistant calls them in-browser via **Vapi** (WebRTC voice)
3. A live call UI shows whether the assistant is speaking and the current audio volume level
4. After the call ends, the backend fetches the call result from Vapi's API and displays a **qualification status** and **call summary**

---

## Tech Stack

| Layer    | Technology                         |
| -------- | ---------------------------------- |
| Frontend | React (Vite)                       |
| Styling  | Plain CSS                          |
| Voice AI | Vapi Web SDK (`@vapi-ai/web`)      |
| Backend  | Flask + Flask-CORS                 |
| Vapi API | REST API for call result retrieval |

---

## How It Works

### Contact Form

On load, the app shows a form with four fields: first name, last name, email, and phone number. The **Start Application Call** button is disabled until all four fields are filled. These values are passed directly to the Vapi assistant as `variableValues` overrides, so the AI can personalize the conversation (e.g., address the user by name).

---

### Starting the Call

When the user clicks **Start Application Call**:

1. `startAssistant()` in `ai.js` is called with the form data.
2. The Vapi Web SDK calls `vapi.start(assistantId, assistantOverrides)`, which initiates a WebRTC voice session in the browser using the configured assistant ID.
3. The Vapi instance emits a `call-start` event, which triggers the UI to hide the form and show the active call interface.

The `assistantId` and the Vapi public key are read from Vite environment variables (`VITE_ASSISTANT_ID` and `VITE_VAPI_API_KEY`).

---

### During the Call

While the call is active, `ActiveCallDetails` is rendered with two live indicators:

- **AssistantSpeechIndicator** — shows a green pulsing dot when the assistant is speaking (driven by Vapi's `speech-start` / `speech-end` events) and a red dot when silent.
- **VolumeLevel** — renders 10 bars, filling them proportionally based on the `volume-level` event emitted by Vapi in real time.

The user can end the call at any time by clicking the **End Call** button.

---

### After the Call

When the call ends (either by the user or the assistant):

1. `stopAssistant()` calls `vapi.stop()` to cleanly terminate the session.
2. `getCallDetails()` begins polling the Flask backend at `GET /call-details?call_id=<id>` every 3 seconds.
3. The backend forwards the request to Vapi's REST API (`GET https://api.vapi.ai/call/{call_id}`) using the server-side API key, and returns the `summary` and `analysis` fields.
4. Polling continues until both fields are populated (Vapi processes them asynchronously after the call ends).
5. Once available, the UI displays:
   - **Qualified** — a boolean from `analysis.structuredData.is_qualified`
   - **Summary** — a natural language recap of the call

The backend acts as a proxy to avoid exposing the Vapi private API key to the browser.

---

## Setup & Installation

### Prerequisites

- Node.js 18+
- Python 3.9+
- A [Vapi](https://vapi.ai/) account with a configured assistant

### Frontend

```bash
npm install
```

### Backend

```bash
pip install flask flask-cors python-dotenv requests
```

---

## Environment Variables

Create a `.env` file in the project root:

```env
# Used by the React frontend (Vite)
VITE_VAPI_API_KEY=your_vapi_public_key
VITE_ASSISTANT_ID=your_vapi_assistant_id

# Used by the Flask backend
VAPI_API_KEY=your_vapi_private_api_key
```

> The frontend uses the **public** Vapi key (safe for the browser). The backend uses the **private** API key to fetch call details server-side.

---

## Running the App

### 1. Start the Flask backend

```bash
python server.py
```

Runs on `http://localhost:5000`.

### 2. Start the React frontend

```bash
npm run dev
```

Runs on `http://localhost:5173` (Vite default). Make sure the fetch URL in `App.jsx` (`/call-details`) is proxied to Flask, or update it to the full URL `http://localhost:5000/call-details`.

---

## API Reference

### Backend (Flask)

| Method | Endpoint                     | Description                                     |
| ------ | ---------------------------- | ----------------------------------------------- |
| `GET`  | `/call-details?call_id=<id>` | Fetch summary and analysis for a completed call |

**Response:**

```json
{
  "summary": "The candidate expressed interest in...",
  "analysis": {
    "structuredData": {
      "is_qualified": true
    }
  }
}
```

Returns `null` for `summary` and `analysis` while Vapi is still processing — the frontend retries automatically every 3 seconds.
