# Device Management System

A full-stack web application for tracking company-owned mobile devices. Built with **ASP.NET Core 8**, **MS SQL Server**, and **Angular 17**.

---

## Features

- **Device CRUD** – Create, view, edit, and delete devices with duplicate validation
- **User Assignment** – Assign/unassign devices to yourself
- **JWT Authentication** – Register and login with secure token-based auth
- **AI Description Generator** – Auto-generate device descriptions using the Anthropic API (with rule-based fallback)
- **Free-text Search** – Ranked search across device fields (name, manufacturer, processor, RAM)
- **Swagger UI** – Explore and test all API endpoints at `/swagger`

---

## Tech Stack

| Layer    | Technology                  |
| -------- | --------------------------- |
| Backend  | C#, ASP.NET Core 8, Web API |
| Database | MS SQL Server + EF Core 8   |
| Frontend | Angular 17 (standalone)     |
| Auth     | JWT Bearer tokens           |
| AI       | Anthropic Claude API        |
| Tests    | xUnit + FluentAssertions    |

---

## Running Locally

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/) and npm
- [Angular CLI](https://angular.io/cli): `npm install -g @angular/cli`
- MS SQL Server (local or Docker)

---

### 1. Database Setup

Run the SQL scripts in order against your SQL Server instance:

```bash
# Using sqlcmd (adjust server name if needed)
sqlcmd -S localhost -E -i database/01_create_db.sql
sqlcmd -S localhost -E -i database/02_seed_data.sql
```

Or open the files in **SQL Server Management Studio** and execute them.

> ℹBoth scripts are **idempotent** — safe to run multiple times.

---

### 2. Backend Setup

```bash
cd backend/DeviceManager.Api
```

Update `appsettings.json` with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=DeviceManager;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Run the API:

```bash
dotnet run
```

The API starts at `http://localhost:5000`.  
Swagger UI is available at: `http://localhost:5000/swagger`

---

### 3. Frontend Setup

```bash
cd frontend
npm install
ng serve
```

The app opens at: `http://localhost:4200`

---

## Default Seed Accounts

After running the seed script, these accounts are available:

| Email                  | Password     | Role        |
| ---------------------- | ------------ | ----------- |
| admin@company.com      | Password123! | Admin       |
| john.doe@company.com   | Password123! | Developer   |
| jane.smith@company.com | Password123! | QA Engineer |
| bob.wilson@company.com | Password123! | Manager     |

---

## Project Structure

```
DeviceManager/
├── database/
│   ├── 01_create_db.sql       # Creates DB + tables (idempotent)
│   └── 02_seed_data.sql       # Populates with dummy data (idempotent)
│
├── backend/
│   ├── DeviceManager.Api/
│   │   ├── Controllers/       # DevicesController, AuthController
│   │   ├── Data/              # EF Core DbContext
│   │   ├── DTOs/              # Request/Response DTOs
│   │   ├── Models/            # Device, User entities
│   │   ├── Services/          # DeviceService, AuthService, AiService
│   │   └── Program.cs         # App entry point + DI setup
│   └── DeviceManager.Tests/   # xUnit integration tests
│
└── frontend/
    └── src/app/
        ├── components/        # Login, Register, DeviceList, DeviceDetail, DeviceForm, Navbar
        ├── services/          # AuthService, DeviceService
        ├── models/            # TypeScript interfaces
        ├── guards/            # AuthGuard
        └── interceptors/      # JWT interceptor
```

---

## API Endpoints

| Method | Endpoint                            | Auth | Description                   |
| ------ | ----------------------------------- | ---- | ----------------------------- |
| POST   | `/api/auth/register`                | No   | Register a new user           |
| POST   | `/api/auth/login`                   | No   | Login, get JWT token          |
| GET    | `/api/devices`                      | Yes  | List all devices              |
| GET    | `/api/devices/{id}`                 | Yes  | Get device by ID              |
| POST   | `/api/devices`                      | Yes  | Create device                 |
| PUT    | `/api/devices/{id}`                 | Yes  | Update device                 |
| DELETE | `/api/devices/{id}`                 | Yes  | Delete device                 |
| POST   | `/api/devices/{id}/assign`          | Yes  | Assign device to yourself     |
| POST   | `/api/devices/{id}/unassign`        | Yes  | Unassign device from yourself |
| GET    | `/api/devices/search?q=query`       | Yes  | Ranked free-text search       |
| POST   | `/api/devices/generate-description` | Yes  | AI-generate description       |

---

## Video Demo

_See `demo.mp4` in the repository root for a full walkthrough of all features with voiceover._
