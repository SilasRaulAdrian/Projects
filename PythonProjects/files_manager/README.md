# Simple Social

A lightweight social media application that lets users register, log in, share images and videos, and browse a live feed — built with **FastAPI** (backend) and **Streamlit** (frontend), using **ImageKit** for media storage and **SQLite** as the database.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [How It Works](#how-it-works)
  - [Authentication](#authentication)
  - [Uploading Media](#uploading-media)
  - [Viewing the Feed](#viewing-the-feed)
  - [Deleting Posts](#deleting-posts)
- [Setup & Installation](#setup--installation)
- [Environment Variables](#environment-variables)
- [Running the App](#running-the-app)
- [API Reference](#api-reference)

---

## Overview

Simple Social is a full-stack social media prototype where users can:

- **Register and log in** using email and password (JWT-based authentication)
- **Upload images and videos** with optional captions
- **Browse a chronological feed** of all posts from all users
- **Delete their own posts**

---

## Tech Stack

| Layer     | Technology                    |
| --------- | ----------------------------- |
| Backend   | FastAPI + FastAPI Users       |
| Frontend  | Streamlit                     |
| Database  | SQLite (via SQLAlchemy async) |
| Media CDN | ImageKit                      |
| Auth      | JWT (Bearer tokens)           |
| ORM       | SQLAlchemy (async)            |

---

## How It Works

### Authentication

Authentication is handled by **FastAPI Users**, a library that provides ready-to-use endpoints for registration, login, and user management.

- **Registration** — `POST /auth/register`  
  Accepts `email` and `password`. Creates a new user in the database.

- **Login** — `POST /auth/jwt/login`  
  Accepts `username` (email) and `password` as form data. Returns a **JWT access token** valid for 1 hour.

- **Protected routes** use the `current_active_user` dependency, which validates the Bearer token on every request.

The Streamlit frontend stores the token in `st.session_state` and passes it as an `Authorization: Bearer <token>` header on all API calls.

---

### Uploading Media

**Route:** `POST /upload`  
**Auth required:** Yes

1. The user selects an image or video file and writes an optional caption in the Streamlit UI.
2. The file is sent to the FastAPI backend as `multipart/form-data`.
3. The backend writes the file to a **temporary file** on disk (using Python's `tempfile` module).
4. The temp file is uploaded to **ImageKit** via their SDK (`imagekit.upload_file`), which stores the media and returns a permanent public URL.
5. A new `Post` record is saved to the SQLite database containing:
   - `user_id` — the ID of the authenticated user
   - `caption` — optional text
   - `url` — the ImageKit CDN URL of the uploaded file
   - `file_type` — `"image"` or `"video"` (detected from the MIME type)
   - `file_name` — the unique filename assigned by ImageKit
6. The temporary file is deleted after upload.

---

### Viewing the Feed

**Route:** `GET /feed`  
**Auth required:** Yes

1. All posts are fetched from the database, ordered by `created_at` descending (newest first).
2. Each post is enriched with the author's email and an `is_owner` flag (whether the logged-in user owns the post).
3. The Streamlit frontend renders each post with:
   - The author's email and post date
   - For **images**: displayed using an ImageKit transformation URL that overlays the caption as a text banner at the bottom of the image.
   - For **videos**: displayed using an ImageKit transformation for consistent sizing (`w-400,h-200,cm-pad_resize,bg-blurred`), with the caption shown below.

**Caption overlays on images** are rendered using ImageKit's URL-based transformations. The caption text is base64-encoded and URL-encoded, then embedded in the image URL as a `l-text` overlay layer — no server-side rendering required.

---

### Deleting Posts

**Route:** `DELETE /posts/{post_id}`  
**Auth required:** Yes

- Only the **owner** of a post can delete it. The backend checks `post.user_id == user.id` and returns a `403 Forbidden` error if they don't match.
- The delete button is only shown in the feed for posts owned by the logged-in user.
- Note: Deletion currently removes the database record only. The file on ImageKit is **not** deleted.

---

## Setup & Installation

### Prerequisites

- Python 3.10+
- An [ImageKit](https://imagekit.io/) account (free tier works)

### Install dependencies

```bash
pip install fastapi uvicorn sqlalchemy aiosqlite fastapi-users[sqlalchemy] \
    streamlit requests imagekitio python-dotenv python-multipart
```

---

## Environment Variables

Create a `.env` file in the project root:

```env
IMAGEKIT_PRIVATE_KEY=your_private_key_here
IMAGEKIT_PUBLIC_KEY=your_public_key_here
IMAGEKIT_URL=https://ik.imagekit.io/your_imagekit_id
```

You can find these values in your ImageKit dashboard under **Developer Options**.

---

## Running the App

### 1. Start the FastAPI backend

```bash
python main.py
```

The API will be available at `http://localhost:8000`.  
Interactive API docs: `http://localhost:8000/docs`

### 2. Start the Streamlit frontend

```bash
streamlit run frontend.py
```

The app will open in your browser at `http://localhost:8501`.

---

## API Reference

| Method   | Endpoint           | Auth | Description                        |
| -------- | ------------------ | ---- | ---------------------------------- |
| `POST`   | `/auth/register`   | No   | Register a new user                |
| `POST`   | `/auth/jwt/login`  | No   | Log in and receive a JWT token     |
| `GET`    | `/users/me`        | Yes  | Get the current authenticated user |
| `POST`   | `/upload`          | Yes  | Upload an image or video post      |
| `GET`    | `/feed`            | Yes  | Get all posts (newest first)       |
| `DELETE` | `/posts/{post_id}` | Yes  | Delete a post (owner only)         |

---

## Notes

- The JWT secret (`SECRET`) in `users.py` is hardcoded for development. **Replace it with a strong secret and load it from the environment before deploying.**
- SQLite is used for simplicity. For production, switch to PostgreSQL by updating `DATABASE_URL` in `db.py` (e.g., `postgresql+asyncpg://...`).
- The database file (`test.db`) is created automatically on first run in the project directory.
