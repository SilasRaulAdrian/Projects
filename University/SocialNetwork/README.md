# Duck Social Network

## Overview

**Duck Social Network** is a Java-based desktop application that simulates a social networking platform, themed around ducks.  
The application allows users to register, authenticate, manage friendships, exchange messages, receive notifications, and participate in events.

The project was developed as an educational application, with a strong focus on object-oriented programming, clean architecture, validation strategies, and database interaction.

---

## Main Features

### User Management
- User registration and authentication
- Secure password handling (hashed passwords)
- User profiles with profile images

### Friendships & Friend Requests
- Send, accept, or reject friend requests
- Manage friend lists
- Prevent duplicate friendships

### Messaging System
- Send and receive messages between users
- Chat-style interface implemented using JavaFX

### Notifications
- Real-time notifications for:
  - Friend requests
  - Messages
  - Events
- Implemented using the Observer design pattern

### Duck Management (Themed Feature)
- Add and manage ducks
- Multiple duck types:
  - Flying ducks
  - Swimming ducks
  - Hybrid ducks
- Cards associated with ducks
- Validation strategies applied to duck-related entities

### Events
- Create and manage duck race events
- Custom validation logic for events

### Pagination
- Pageable data access for large collections (friends, messages, etc.)

---

## Project Architecture

The application follows a **layered architecture**:

### Presentation Layer (UI)
- Built using **JavaFX**
- `.fxml` files define the views
- Controllers manage user interactions  
  (e.g. `LoginController`, `ChatController`, `FriendRequestsController`)

### Service Layer
- Contains the core business logic
- Coordinates repositories and validations  
  (e.g. `UserService`, `FriendshipService`, `MessageService`)

### Repository Layer
- Responsible for data persistence
- Uses repository interfaces and concrete implementations
- Database connections are managed through a connection manager

### Domain Layer
- Core entities of the application:
  - `User`, `Person`
  - `Friendship`, `FriendRequest`
  - `Message`, `Notification`
  - `Duck`, `Card`, `Event`
- Strong use of OOP principles:
  - Encapsulation
  - Inheritance
  - Polymorphism
  - Interfaces

---

## Design Patterns Used

- **MVC (Model–View–Controller)**
- **Observer Pattern** – used for notifications and UI updates
- **Strategy Pattern** – used for validation logic
- **Repository Pattern** – used for data access abstraction

---

## Technologies Used

- Java
- JavaFX
- Gradle
- PostgreSQL (or another relational database)
- FXML
- Javadoc

---

## How to Run the Application

1. Open the project in an IDE (IntelliJ IDEA recommended)
2. Load all Gradle dependencies
3. Configure the database connection in `ConnectionManager`
4. Run the `Main` class

---

## Documentation

- Javadoc documentation is available in the `JavaDoc` directory

---

## Purpose

This project was created for academic purposes and demonstrates:
- Clean and layered architecture
- Object-oriented design principles
- Usage of design patterns
- GUI development with JavaFX
- Database-backed application development
