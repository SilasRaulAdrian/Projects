# Code Challenge Generator

A full-stack app that generates AI-powered coding challenges with multiple choice answers. Built with FastAPI, React, Ollama, and Clerk for authentication.

---

## How It Works

1. User logs in via **Clerk** (JWT auth)
2. Frontend requests a challenge at a chosen difficulty
3. Backend checks the user's **daily quota** (resets every 24h)
4. **Ollama** (`llama3`) generates a question, 4 options, and an explanation
5. Challenge is saved to **SQLite** and returned to the user
6. User can view their full challenge **history**

```
React Frontend (Vite)
      │  Bearer token (Clerk JWT)
      ▼
FastAPI Backend
      ├── Auth → Clerk SDK validates JWT
      ├── Quota check → SQLite (10/day per user)
      ├── AI Generation → Ollama llama3 (local)
      └── Storage → SQLite via SQLAlchemy
```

---

## Setup

### Prerequisites

- Python 3.10+, Node.js 18+, Ollama with `llama3` pulled
- A [Clerk](https://clerk.com) account

```bash
ollama pull llama3
```

### Backend

```bash
cd backend
pip install fastapi uvicorn sqlalchemy clerk-backend-api svix ollama python-dotenv
```

Create `.env`:

```env
CLERK_SECRET_KEY=your_clerk_secret_key
CLERK_WEBHOOK_SECRET=your_clerk_webhook_secret
JWT_KEY=your_clerk_jwt_key
```

Run:

```bash
python main.py
```

### Frontend

```bash
cd frontend
npm install
```

Create `.env`:

```env
VITE_CLERK_PUBLISHABLE_KEY=your_clerk_publishable_key
```

Run:

```bash
npm run dev
```

---

## API Endpoints

| Method | Endpoint                  | Description                  |
| ------ | ------------------------- | ---------------------------- |
| `POST` | `/api/generate-challenge` | Generate a new AI challenge  |
| `GET`  | `/api/my-history`         | Get user's challenge history |
| `GET`  | `/api/quota`              | Get remaining daily quota    |
| `POST` | `/webhooks/clerk`         | Clerk user.created webhook   |

All `/api` routes require a valid Clerk JWT in the `Authorization` header.

---

## Key Features

- **Daily quota** — 10 challenges per user, auto-resets every 24 hours
- **Clerk webhook** — quota record is created automatically on user signup
- **Local AI** — runs entirely on your machine via Ollama, no external AI API costs
- **Difficulty levels** — Easy, Medium, Hard, each with tailored prompt instructions

---

## Environment Variables

| Variable                     | Where    | Description               |
| ---------------------------- | -------- | ------------------------- |
| `CLERK_SECRET_KEY`           | Backend  | Clerk API secret          |
| `CLERK_WEBHOOK_SECRET`       | Backend  | Svix webhook verification |
| `JWT_KEY`                    | Backend  | Clerk JWT public key      |
| `VITE_CLERK_PUBLISHABLE_KEY` | Frontend | Clerk publishable key     |
