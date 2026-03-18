# ImageKit Video Platform

A full-stack Next.js video platform that lets you upload, manage, and stream videos with built-in support for watermarking, thumbnail generation, and adaptive quality control — all powered by [ImageKit](https://imagekit.io/).

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [How It Works](#how-it-works)
  - [Video Upload Flow](#video-upload-flow)
  - [Video Storage](#video-storage)
  - [Video Playback](#video-playback)
  - [Watermarking](#watermarking)
  - [Thumbnail Generation](#thumbnail-generation)
- [API Reference](#api-reference)
- [Environment Variables](#environment-variables)
- [Getting Started](#getting-started)
- [Usage Guide](#usage-guide)

---

## Overview

This project is a self-hosted video library built with Next.js App Router. It uses ImageKit as the media CDN and transformation engine — videos are uploaded directly to ImageKit from the browser (using server-generated auth tokens), and then streamed back with on-the-fly transformations like quality adjustment, format conversion, and image overlay watermarks.

Video metadata (title, description, file paths, watermark config, etc.) is stored in a local JSON file (`data/videos.json`), making the project easy to run without any external database.

---

## Features

- **Video upload** with title, description, thumbnail, and optional watermark image
- **Auto-thumbnail generation** via ImageKit's `ik-thumbnail.jpg` endpoint
- **Watermarking** — overlay a custom image at a configurable position
- **Quality control** — adjust video quality (1–100) directly from the player
- **Video library** — browse all uploaded videos with thumbnails and dates
- **Secure uploads** — auth tokens generated server-side, never exposing the private key

---

## Tech Stack

| Layer        | Technology                           |
| ------------ | ------------------------------------ |
| Framework    | Next.js 14+ (App Router)             |
| Media CDN    | ImageKit                             |
| ImageKit SDK | `@imagekit/next`                     |
| Storage      | Local JSON file (`data/videos.json`) |
| Styling      | CSS Modules / global CSS             |
| Language     | TypeScript                           |

---

## Project Structure

```
.
├── app/
│   ├── layout.tsx              # Root layout — wraps app in ImageKitProvider + nav
│   ├── page.tsx                # Home page — renders the video library
│   ├── upload/
│   │   └── page.tsx            # Upload page
│   └── watch/
│       └── [id]/
│           └── page.tsx        # Watch page for a specific video
├── api/
│   ├── upload-auth/
│   │   └── route.ts            # Generates ImageKit upload auth tokens (GET)
│   └── videos/
│       ├── route.ts            # List all videos (GET) / create video record (POST)
│       └── [id]/
│           └── route.ts        # Fetch a single video by ID (GET)
├── components/
│   └── video/
│       ├── VideoUpload.tsx     # Upload form component
│       ├── VideoLibrary.tsx    # Grid of video thumbnails
│       └── player/
│           └── SimplePlayer.tsx # Video player with quality control
├── lib/
│   └── video-storage.ts        # JSON file read/write helpers
├── types/
│   └── video.ts                # TypeScript interfaces (Video, WatermarkConfig)
├── styles/                     # CSS files
└── data/
    └── videos.json             # Auto-created — stores all video metadata
```

---

## How It Works

### Video Upload Flow

Uploads use a **server-authenticated, client-side upload** pattern to keep the ImageKit private key secure:

1. The user fills in the upload form (title, description, video file, optional thumbnail and watermark).
2. On submit, the browser calls `GET /api/upload-auth` to get a short-lived auth token (signature + expire + token) signed with the private key server-side.
3. The `upload()` function from `@imagekit/next` uploads the file **directly from the browser to ImageKit**, using the auth token.
4. After all files are uploaded, the browser sends a `POST /api/videos` request with the resulting file paths and metadata.
5. The server saves the record to `data/videos.json` and returns the new video object.
6. The user is redirected to the watch page.

```
Browser → GET /api/upload-auth → Server (signs with private key) → returns token
Browser → upload(file, token) → ImageKit CDN
Browser → POST /api/videos { filePath, title, ... } → Server → writes to videos.json
Browser → redirect to /watch/[id]
```

### Video Storage

There is no external database. Video metadata is stored in `data/videos.json` as a JSON array, managed by `lib/video-storage.ts`. The file is created automatically on first run.

Each video record looks like:

```json
{
  "id": "uuid-v4",
  "title": "My Video",
  "description": "A short description",
  "filePath": "/videos/my-video.mp4",
  "fileName": "my-video.mp4",
  "thumbnailPath": "/thumbnails/thumb.jpg",
  "createdAt": "2024-01-01T00:00:00.000Z",
  "watermark": {
    "imagePath": "/watermarks/logo.png",
    "position": "bottom_right",
    "opacity": 0.7,
    "width": 120
  }
}
```

### Video Playback

The `SimplePlayer` component renders an ImageKit `<Video>` element with on-the-fly transformations applied via the `transformation` prop. Transformations are re-applied every time the user changes the quality slider (the `key` prop forces a re-mount).

Supported transformations applied at playback time:

- `quality` — integer 1–100 controlling compression
- `format` — optional format override (`mp4`, `webm`, `auto`)
- `overlay` — watermark image positioned on top of the video

### Watermarking

Watermarks are applied as **ImageKit overlay transformations** at stream time — the original video file is never modified. The watermark image path, position, and width are stored in the video metadata and passed as a transformation layer when building the video URL.

Supported positions: `top_left`, `top_right`, `bottom_left`, `bottom_right`.

### Thumbnail Generation

If no custom thumbnail is uploaded, the player and library fall back to ImageKit's automatic video thumbnail endpoint:

```
{filePath}/ik-thumbnail.jpg
```

This is a built-in ImageKit feature that extracts a frame from the video automatically — no extra processing needed.

---

## API Reference

### `GET /api/upload-auth`

Returns a signed upload token for use with the ImageKit client-side upload SDK.

**Response:**

```json
{
  "token": "...",
  "expire": 1700000000,
  "signature": "...",
  "publicKey": "public_..."
}
```

---

### `GET /api/videos`

Returns all stored videos.

**Response:**

```json
{
  "videos": [ { ...Video }, ... ]
}
```

---

### `POST /api/videos`

Saves a new video record.

**Request body:**

```json
{
  "title": "string",
  "description": "string",
  "filePath": "string",
  "fileName": "string",
  "thumbnailPath": "string (optional)",
  "duration": "number (optional)",
  "watermark": {
    "imagePath": "string",
    "position": "bottom_right",
    "opacity": 0.7,
    "width": 120
  }
}
```

**Response:** `201` with the created video object.

---

### `GET /api/videos/[id]`

Returns a single video by its UUID.

**Response:**

```json
{
  "video": { ...Video }
}
```

---

## Environment Variables

Create a `.env.local` file in the project root:

```env
IMAGEKIT_PRIVATE_KEY=your_imagekit_private_key
IMAGEKIT_PUBLIC_KEY=your_imagekit_public_key
NEXT_PUBLIC_IMAGEKIT_URL_ENDPOINT=https://ik.imagekit.io/your_imagekit_id
```

You can find these in your [ImageKit dashboard](https://imagekit.io/dashboard) under **Developer Options**.

---

## Getting Started

```bash
# 1. Clone the repository
git clone https://github.com/your-username/your-repo.git
cd your-repo

# 2. Install dependencies
npm install

# 3. Set up environment variables
cp .env.example .env.local
# Fill in your ImageKit credentials

# 4. Run the development server
npm run dev
```

Open [http://localhost:3000](http://localhost:3000) in your browser.

---

## Usage Guide

### Uploading a Video

1. Navigate to **Upload** in the top navigation.
2. Fill in the **Title** (optional — defaults to "Untitled Video").
3. Add an optional **Description**.
4. Select your **Video File** (required).
5. Optionally select a **Thumbnail image** — if omitted, one is generated automatically from the video.
6. Optionally select a **Watermark image** — it will be overlaid at the bottom-right corner during playback.
7. Click **Upload** and wait for the upload to complete.
8. You will be redirected to the video watch page automatically.

### Watching a Video

- Use the native browser video controls to play/pause, seek, and adjust volume.
- Use the **Quality** number input below the player to change the streaming quality (1 = lowest, 100 = highest). The video will reload with the new quality applied.

### Browsing the Library

- The home page (`/`) shows all uploaded videos as a thumbnail grid.
- Click any video card to go to its watch page.
