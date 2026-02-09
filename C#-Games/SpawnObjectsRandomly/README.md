# Spawn Objects Randomly Application

## Overview

**Spawn Objects Randomly** is a simple desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application demonstrates how to create and place objects randomly on the screen at runtime. It is commonly used as a learning example for randomization and dynamic UI element creation.

This project demonstrates:
- Dynamic object creation in WinForms
- Random positioning logic
- Timer-based spawning
- Event-driven programming

---

## Application Concept

The application focuses on spawning objects dynamically:
- Objects (such as PictureBox controls) are created at runtime
- Each object is placed at a random position on the form
- Objects may appear continuously or at set intervals

---

## How the Application Works

### Object Spawning Logic

- Objects are created programmatically
- A random number generator determines:
  - X position
  - Y position
- Objects are added to the form dynamically

---

### Spawning Control

- Spawning can be:
  - Automatic using a timer
  - Triggered by a button
- The number of objects may increase over time

---

### Interaction (if implemented)

- Objects may be clickable
- Clicking an object can:
  - Remove it
  - Change its appearance
  - Increase a counter

---

## Controls

| Action | Input |
|------|------|
| Spawn objects | Automatic or button click |
| Interact with objects | Mouse click |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. Objects begin spawning at random positions
3. The user may interact with spawned objects
4. Objects continue to appear based on logic
5. The application runs until closed

---

## Visual Feedback

- Randomly placed objects
- Immediate appearance on spawn
- Simple and clear visual behavior

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: SpawnObjectsRandomly/bin/Debug/
2. Run `SpawnObjectsRandomly.exe`

### Option 2: Run from Visual Studio
1. Open `SpawnObjectsRandomly.sln`
2. Build the solution
3. Press **F5** to start the application

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project is useful for learning:
- Random number generation
- Dynamic UI creation
- Timer-based logic
- Event-driven programming in WinForms

---

## Possible Improvements

- Limit the number of spawned objects
- Add collision detection
- Add animations
- Add clear/remove all objects button
- Add performance optimizations
