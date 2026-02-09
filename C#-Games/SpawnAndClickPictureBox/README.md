# Spawn And Click PictureBox Application

## Overview

**Spawn And Click PictureBox** is a simple interactive desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application dynamically spawns images (`PictureBox` controls) on the screen, and the user must click on them to interact, remove them, or increase a score.

This project demonstrates:
- Dynamic control creation in WinForms
- Mouse click event handling
- Random positioning of UI elements
- Basic interaction logic

---

## Application Concept

The application is based on a simple spawn-and-click mechanic:
- PictureBox objects appear dynamically on the screen
- Each PictureBox is clickable
- Clicking a PictureBox triggers a specific action (remove, score, respawn)

This type of logic is often used as the base for simple games or UI interaction demos.

---

## How the Application Works

### PictureBox Spawning

- The application creates `PictureBox` controls at runtime
- Each PictureBox:
  - Uses an image resource
  - Is placed at a random position within the form
- Spawning can occur:
  - Automatically using a timer
  - Or manually via a button

---

### Click Handling Logic

- Each PictureBox has a click event attached
- When clicked:
  - The PictureBox is removed or hidden
  - A score or counter may be increased
  - A new PictureBox may spawn

---

### Game / Interaction Loop

1. PictureBoxes are spawned on the form
2. The user clicks on them
3. The application processes the click event
4. The UI updates dynamically
5. The process repeats

---

## Controls

| Action | Input |
|------|------|
| Click PictureBox | Left mouse click |
| Spawn objects | Automatic or button click |
| Exit application | Close window |

---

## Visual Feedback

- Dynamically appearing images
- Immediate response to mouse clicks
- Simple and clean interaction

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: SpawnAndClickPictureBox/bin/Debug/
2. Run `SpawnAndClickPictureBox.exe`

### Option 2: Run from Visual Studio
1. Open `SpawnAndClickPictureBox.sln`
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
- Runtime control creation
- Event handling with dynamically created elements
- Random positioning logic
- Interactive WinForms applications

---

## Possible Improvements

- Add score display
- Add difficulty (faster spawn rate)
- Add time limit
- Add sound effects
- Add different PictureBox types
