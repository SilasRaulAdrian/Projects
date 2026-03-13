# TaskBoard

A full-stack B2B task management application built with **React + Clerk** on the frontend and **FastAPI + SQLAlchemy** on the backend. Organizations can manage tasks on a Kanban board, with role-based access control and subscription-based membership limits powered by Clerk Billing.

---

## Table of Contents

- [Tech Stack](#tech-stack)
- [How It Works](#how-it-works)
  - [Authentication & Organizations](#authentication--organizations)
  - [Role-Based Permissions](#role-based-permissions)
  - [Subscription & Billing](#subscription--billing)
  - [Task Management](#task-management)
- [Project Structure](#project-structure)
- [Environment Variables](#environment-variables)
- [Getting Started](#getting-started)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
- [API Reference](#api-reference)
- [Clerk Setup Guide](#clerk-setup-guide)

---

## Tech Stack

| Layer       | Technology                              |
| ----------- | --------------------------------------- |
| Frontend    | React 18, React Router v6, Vite         |
| Auth & Orgs | Clerk (React SDK + Backend SDK)         |
| Backend     | FastAPI, Uvicorn                        |
| Database    | SQLite via SQLAlchemy ORM               |
| Billing     | Clerk Billing (PricingTable + Webhooks) |
| Validation  | Pydantic v2                             |

---

## How It Works

### Authentication & Organizations

All authentication is handled by **Clerk**. Users sign up/sign in through Clerk's hosted UI components (`<SignIn />`, `<SignUp />`). The app is fully **organization-scoped** — every task belongs to an organization (`org_id`), and users must be a member of an organization to use the dashboard.

- The `<OrganizationSwitcher />` component in the navbar lets users switch between organizations or create new ones.
- If a user is authenticated but has no active organization, the dashboard prompts them to create one via Clerk's `<CreateOrganization />` component.
- On the backend, every request is authenticated by verifying the **JWT session token** sent as a `Bearer` token in the `Authorization` header. The token is verified using Clerk's `authenticate_request()` method, which validates the token against Clerk's JWKS endpoint and checks the `authorized_parties` (allowed frontend origins).

**JWT Claims used by the backend:**

| Claim             | Description                                               |
| ----------------- | --------------------------------------------------------- |
| `sub`             | The user's unique Clerk user ID                           |
| `org_id`          | The currently active organization ID                      |
| `org_permissions` | List of fine-grained permissions for the user in this org |

---

### Role-Based Permissions

The app uses **Clerk's fine-grained permissions** system (not just roles). Each user's JWT contains an `org_permissions` array. The backend checks these permissions on every request.

**Defined permissions:**

| Permission         | What it allows        |
| ------------------ | --------------------- |
| `org:tasks:view`   | Read / list tasks     |
| `org:tasks:create` | Create new tasks      |
| `org:tasks:edit`   | Update existing tasks |
| `org:tasks:delete` | Delete tasks          |

These permissions must be configured in your **Clerk Dashboard → Roles & Permissions**. You typically assign them to roles like `org:admin`, `org:editor`, `org:viewer`.

On the frontend, edit/delete buttons are only rendered for members whose role is `org:admin` or `org:editor` (checked via `membership.role`). On the backend, all four permissions are enforced independently using FastAPI dependency injection:

```python
# Example — only users with org:tasks:create can hit this endpoint
@router.post("", response_model=TaskResponse)
def create_task(user: AuthUser = Depends(require_create), ...):
    ...
```

---

### Subscription & Billing

Billing is handled via **Clerk Billing**. The pricing page uses Clerk's `<PricingTable for="organization" />` component, which is only visible to organization admins. Non-admins see a message to contact their admin.

**Plans:**

| Plan             | Member Limit                                   |
| ---------------- | ---------------------------------------------- |
| Free             | 2 members (`FREE_TIER_LIMIT = 2`)              |
| Pro (`pro_tier`) | Unlimited (`1,000,000` as a practical ceiling) |

**How limits are enforced:**

When a subscription is created, updated, deleted, or cancelled, Clerk sends a **webhook event** to `/api/webhooks/clerk`. The backend processes these events and updates the organization's `max_allowed_memberships` via the Clerk Management API:

```
subscription.created / subscription.updated
  → Check if any item has plan.slug == "pro_tier" and status == "active"
  → If yes: set max_allowed_memberships = 1,000,000
  → If no:  set max_allowed_memberships = 2

subscription.deleted / subscription.cancelled
  → set max_allowed_memberships = 2 (downgrade to free)
```

Clerk itself enforces the membership cap — it will reject invitations that would exceed `max_allowed_memberships`. The webhook endpoint validates the request signature using the **Svix** library and `CLERK_WEBHOOK_SECRET` (if configured).

---

### Task Management

Tasks are stored in a local **SQLite database** (configurable via `DATABASE_URL`). Each task has:

| Field         | Type        | Description                                     |
| ------------- | ----------- | ----------------------------------------------- |
| `id`          | UUID string | Auto-generated primary key                      |
| `title`       | String      | Required task title                             |
| `description` | Text        | Optional description                            |
| `status`      | Enum        | `pending`, `started`, or `completed`            |
| `org_id`      | String      | Clerk organization ID (multi-tenancy isolation) |
| `created_by`  | String      | Clerk user ID of the creator                    |
| `created_at`  | DateTime    | Auto-set on creation                            |
| `updated_at`  | DateTime    | Auto-set on creation (update manually on edit)  |

Tasks are fetched once on dashboard load and managed in local React state, with **optimistic updates** — the UI updates immediately and rolls back if the API call fails.

The Kanban board has three columns: **To Do** (`pending`), **In Progress** (`started`), and **Done** (`completed`).

---

## Project Structure

```
.
├── backend/
│   ├── app/
│   │   ├── api/
│   │   │   ├── tasks.py         # Task CRUD endpoints
│   │   │   └── webhooks.py      # Clerk billing webhook handler
│   │   ├── core/
│   │   │   ├── auth.py          # JWT verification, AuthUser, permission deps
│   │   │   ├── clerk.py         # Clerk SDK client singleton
│   │   │   ├── config.py        # Settings from environment variables
│   │   │   └── database.py      # SQLAlchemy engine, session, Base
│   │   ├── models/
│   │   │   └── task.py          # Task SQLAlchemy model
│   │   ├── schemas/
│   │   │   └── task.py          # Pydantic request/response schemas
│   │   └── main.py              # FastAPI app, CORS, router registration
│   └── start.py                   # Uvicorn entrypoint
│
└── frontend/
    └── src/
        ├── components/
        │   ├── KanbanBoard.jsx  # Board container, handles task state & actions
        │   ├── TaskColumn.jsx   # Single status column
        │   ├── TaskCard.jsx     # Individual task card
        │   ├── TaskForm.jsx     # Create/edit modal form
        │   └── Layout.jsx       # Navbar with Clerk components
        ├── pages/
        │   ├── HomePage.jsx     # Landing page
        │   ├── DashboardPage.jsx# Main app page, loads tasks
        │   ├── PricingPage.jsx  # Clerk PricingTable
        │   ├── SignInPage.jsx   # Clerk SignIn component
        │   └── SignUp.jsx       # Clerk SignUp component
        ├── services/
        │   └── api.js           # Fetch helpers with Bearer token auth
        ├── App.jsx              # Routes + ProtectedRoute wrapper
        └── main.jsx             # ClerkProvider + BrowserRouter root
```

---

## Environment Variables

### Backend (`.env`)

```env
CLERK_SECRET_KEY=sk_...          # From Clerk Dashboard → API Keys
CLERK_PUBLISHABLE_KEY=pk_...     # From Clerk Dashboard → API Keys
CLERK_WEBHOOK_SECRET=whsec_...   # From Clerk Dashboard → Webhooks (optional but recommended)
DATABASE_URL=sqlite:///./tasks.db
FRONTEND_URL=http://localhost:5173
```

### Frontend (`.env`)

```env
VITE_CLERK_PUBLISHABLE_KEY=pk_...
VITE_API_URL=http://localhost:8000
```

---

## Getting Started

### Backend Setup

1. **Install dependencies**

   ```bash
   cd backend
   python -m venv venv
   source venv/bin/activate  # Windows: venv\Scripts\activate
   pip install fastapi uvicorn sqlalchemy python-dotenv clerk-backend-api svix httpx
   ```

2. **Configure environment**

   Create a `.env` file in the `backend/` directory using the variables listed above.

3. **Run the server**

   ```bash
   python run.py
   # or
   uvicorn app.main:app --reload --port 8000
   ```

   The database and tables are created automatically on startup via `Base.metadata.create_all()`.

### Frontend Setup

1. **Install dependencies**

   ```bash
   cd frontend
   npm install
   ```

2. **Configure environment**

   Create a `.env` file in the `frontend/` directory using the variables listed above.

3. **Run the dev server**

   ```bash
   npm run dev
   ```

   The app will be available at `http://localhost:5173`.

---

## API Reference

All endpoints require a valid Clerk session JWT in the `Authorization: Bearer <token>` header. The token is obtained via Clerk's `useAuth().getToken()` hook.

| Method   | Endpoint              | Permission         | Description                                   |
| -------- | --------------------- | ------------------ | --------------------------------------------- |
| `GET`    | `/api/tasks`          | `org:tasks:view`   | List all tasks for the active organization    |
| `POST`   | `/api/tasks`          | `org:tasks:create` | Create a new task                             |
| `GET`    | `/api/tasks/{id}`     | `org:tasks:view`   | Get a single task by ID                       |
| `PUT`    | `/api/tasks/{id}`     | `org:tasks:edit`   | Update a task's title, description, or status |
| `DELETE` | `/api/tasks/{id}`     | `org:tasks:delete` | Delete a task                                 |
| `POST`   | `/api/webhooks/clerk` | — (Svix signature) | Clerk billing webhook receiver                |

Tasks are automatically scoped to the calling user's active `org_id` — users can never read or modify tasks from other organizations.

---

## Clerk Setup Guide

1. **Create a Clerk application** at [clerk.com](https://clerk.com) and enable **Organizations**.

2. **Configure Roles & Permissions** in your Clerk Dashboard:
   - Create permissions: `org:tasks:view`, `org:tasks:create`, `org:tasks:edit`, `org:tasks:delete`
   - Assign them to roles (e.g., give all four to `org:admin` and `org:editor`; only `view` to `org:viewer`)

3. **Enable Clerk Billing** and create a **Pro plan** with the slug `pro_tier`.

4. **Register a webhook** in your Clerk Dashboard pointing to `https://your-domain.com/api/webhooks/clerk`. Subscribe to these events:
   - `subscription.created`
   - `subscription.updated`
   - `subscription.deleted`
   - `subscription.cancelled`

   Copy the **Signing Secret** into `CLERK_WEBHOOK_SECRET`.

5. **Set JWT template** (optional but recommended): ensure `org_permissions` is included in the session token claims. Clerk includes this by default when fine-grained permissions are enabled.
