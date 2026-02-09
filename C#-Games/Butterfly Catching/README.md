# Butterfly Catching Game

## Overview

**Butterfly Catching Game** is a simple 2D arcade-style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The goal of the game is to catch moving butterflies by clicking on them before they escape the screen. The game focuses on speed, accuracy, and user interaction.

This project demonstrates:
- Mouse event handling
- Timer-based movement
- Random positioning of objects
- Basic score tracking in WinForms

---

## Game Concept

The game simulates a butterfly-catching activity:
- Butterflies move randomly across the screen
- The player must click on them to catch them
- Each successful catch increases the score
- The game continues until a specific condition is met or the application is closed

---

## How the Game Works

### Game Objects

- **Butterflies**
  - Represented using images (`PictureBox` controls)
  - Move automatically using a timer
  - Reposition randomly after being caught

- **Score Display**
  - Shows the current number of butterflies caught
  - Updates instantly after each successful click

---

### Game Loop

The main logic runs using a `Timer`:
1. On every timer tick:
   - Butterflies change position or move across the screen
   - New random positions are generated
2. The game continuously updates until stopped

---

### Catching a Butterfly

- The player clicks on a butterfly image
- When clicked:
  - The butterfly is considered “caught”
  - The score increases by 1
  - The butterfly is moved to a new random position

---

## Controls

| Action | Input |
|------|------|
| Catch butterfly | Left mouse click |
| Exit game | Close window |

---

## Game Flow

1. The game starts automatically when launched
2. Butterflies begin moving on the screen
3. The player clicks on butterflies to catch them
4. The score updates continuously
5. The game runs until the player exits

---

## Visual Feedback

- Moving butterfly images provide dynamic gameplay
- The score label gives immediate feedback
- Smooth movement improves user interaction

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: Butterfly Catching/bin/Debug/
2. Run `ButterflyCatching.exe`

### Option 2: Run from Visual Studio
1. Open `Butterfly Catching.sln`
2. Build the solution
3. Press **F5** to start the game

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project is useful for learning:
- Mouse click event handling
- Timers for animation
- Random number generation
- Simple interactive game logic

---

## Possible Improvements

- Add a time limit
- Add difficulty levels (faster butterflies)
- Add sound effects
- Add multiple butterfly types
- Add a high-score system
