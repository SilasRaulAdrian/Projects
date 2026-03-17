# Reddit Clone

A full-stack Reddit-like web application built with **React**, **Convex**, and **Clerk**. Users can create communities (subreddits), post content with optional images, vote on posts, and comment — all in real time.

---

## Tech Stack

| Layer              | Technology                                    |
| ------------------ | --------------------------------------------- |
| Frontend           | React + TypeScript + React Router             |
| Backend / Database | [Convex](https://convex.dev) (real-time BaaS) |
| Authentication     | [Clerk](https://clerk.dev)                    |
| Vote counting      | `@convex-dev/sharded-counter`                 |
| Image storage      | Convex Storage                                |

---

## Features

- **Communities** — Create and browse subreddits (`r/<name>`)
- **Posts** — Create text posts with optional image attachments (up to 5 MB)
- **Voting** — Upvote / downvote posts; votes are mutually exclusive per user
- **Comments** — Paginated comment threads on each post
- **Search** — Search communities from the home page; search posts within a subreddit
- **Profiles** — Public user profile page showing post count and post history
- **Trending feed** — Home page shows the top-scored posts from the last 24 hours
- **Real-time updates** — All data is reactive via Convex; no manual refresh needed

---

## Project Structure

```
/
├── convex/                  # Backend (Convex functions + schema)
│   ├── schema.ts            # Database schema
│   ├── auth.config.ts       # Clerk JWT configuration
│   ├── http.ts              # Clerk webhook handler
│   ├── users.ts             # User CRUD + Clerk sync
│   ├── post.ts              # Post queries & mutations
│   ├── comments.ts          # Comment queries & mutations
│   ├── subreddit.ts         # Subreddit queries & mutations
│   ├── vote.ts              # Upvote / downvote logic
│   ├── leaderboard.ts       # Trending posts query
│   ├── counter.ts           # Sharded counter helpers
│   ├── image.ts             # Image upload URL generation
│   └── convex.config.ts     # Convex app config (sharded counter component)
│
└── src/                     # Frontend (React)
    ├── components/
    │   ├── Navbar.tsx
    │   ├── SearchBar.tsx
    │   ├── PostCard.tsx
    │   ├── Comment.tsx
    │   ├── Feed.tsx
    │   ├── Layout.tsx
    │   ├── CreateDropdown.tsx
    │   └── CreateCommunityModal.tsx
    ├── pages/
    │   ├── HomePage.tsx
    │   ├── SubredditPage.tsx
    │   ├── PostPage.tsx
    │   ├── ProfilePage.tsx
    │   └── SubmitPage.tsx
    ├── styles/
    └── main.tsx
```

---

## Database Schema

| Table       | Fields                                               | Purpose                       |
| ----------- | ---------------------------------------------------- | ----------------------------- |
| `users`     | `username`, `externalId`                             | Synced from Clerk via webhook |
| `subreddit` | `name`, `description`, `authorId`                    | Communities                   |
| `post`      | `subject`, `body`, `subreddit`, `authorId`, `image?` | Posts                         |
| `comments`  | `content`, `postId`, `authorId`                      | Comments on posts             |
| `upvote`    | `postId`, `userId`                                   | Per-user upvote records       |
| `downvote`  | `postId`, `userId`                                   | Per-user downvote records     |

Vote and comment counts are maintained separately via **sharded counters** for efficient high-frequency increments/decrements without contention.

---

## Getting Started

### Prerequisites

- Node.js 18+
- A [Convex](https://dashboard.convex.dev) account
- A [Clerk](https://dashboard.clerk.dev) account

### 1. Clone and install dependencies

```bash
git clone <repo-url>
cd <project-folder>
npm install
```

### 2. Set up Convex

```bash
npx convex dev
```

This will prompt you to log in and link or create a Convex project. It also starts the local dev backend and keeps functions in sync.

### 3. Configure environment variables

Create a `.env.local` file in the project root (the `.env` file already contains the Convex deployment URL):

```env
CONVEX_DEPLOYMENT=dev:your-deployment-id
VITE_CONVEX_URL=https://your-deployment.convex.cloud
VITE_CONVEX_SITE_URL=https://your-deployment.convex.site
```

### 4. Configure Clerk

In your Clerk dashboard:

1. Create a new application
2. Under **JWT Templates**, create a template named `convex` and point it at your Convex deployment
3. Copy your **Frontend API URL** into `convex/auth.config.ts`:

```ts
domain: "https://<your-clerk-frontend-api>",
applicationID: "convex",
```

4. Set up a **webhook** in Clerk pointing to:

```
https://<your-convex-site-url>/clerk-users-webhook
```

Enable the `user.created`, `user.updated`, and `user.deleted` events.

5. Add the webhook secret to your Convex dashboard environment variables:

```
CLERK_WEBHOOK_SECRET=whsec_...
```

6. Update the Clerk `publishableKey` in `src/main.tsx` with your own key.

### 5. Start the frontend

```bash
npm run dev
```

Open [http://localhost:5173](http://localhost:5173).

---

## How It Works

### Authentication

Clerk handles sign-in/sign-up via a modal. On user creation or update, Clerk sends a webhook to Convex (`/clerk-users-webhook`), which upserts the user record in the `users` table. The frontend uses `ConvexProviderWithClerk` so all Convex queries and mutations run with the authenticated user's identity.

### Creating a Community

Click the **+** button in the navbar (requires sign-in), then choose **Community**. Community names must be 3–21 characters and can only contain letters, numbers, and underscores. Names are unique and cannot be changed.

### Creating a Post

Navigate to a subreddit (`r/<name>`), click **+**, then **Post**. You can add a title (required), an optional body, and an optional image (max 5 MB). Images are uploaded directly to Convex Storage and the storage ID is attached to the post.

### Voting

Each post displays upvote and downvote buttons. Votes are mutually exclusive — casting one type removes the other. Vote totals are tracked using sharded counters for scalability.

### Comments

Comments are loaded in pages of 20 and can be paginated via a **Load More** button. Posting a comment requires being signed in.

### Search

- On the **home page**, the search bar searches for communities by name.
- Inside a **subreddit**, the search bar searches for posts by title within that subreddit (full-text search via Convex search indexes).

### Trending Feed

The home page shows up to 10 posts from the last 24 hours, ranked by score (`upvotes − downvotes`).

---

## Key Convex Patterns Used

- **`paginationOptsValidator`** — all list queries (posts, comments) are paginated
- **`withSearchIndex`** — full-text search on post subjects and subreddit names
- **`ShardedCounter`** — high-throughput counters for votes, comments, and post counts
- **`ctx.storage.generateUploadUrl()`** — client-side direct uploads to Convex Storage
- **`internalMutation`** — user sync from Clerk webhooks runs as an internal (non-public) mutation

---

## Scripts

| Command             | Description                        |
| ------------------- | ---------------------------------- |
| `npm run dev`       | Start Vite dev server              |
| `npx convex dev`    | Start Convex backend in watch mode |
| `npx convex deploy` | Deploy backend to production       |
| `npm run build`     | Build frontend for production      |
