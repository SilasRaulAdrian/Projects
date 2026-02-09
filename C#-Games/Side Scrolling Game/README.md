# Side Scrolling Game

## Overview

**Side Scrolling Game** is a simple 2D side-scrolling game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a character that moves horizontally across the screen while the environment scrolls from right to left. The goal is to avoid obstacles and survive for as long as possible or reach the end of the level.

This project demonstrates:
- Side-scrolling mechanics
- Timer-based game loops
- Keyboard input handling
- Collision detection in WinForms

---

## Game Concept

The game follows a classic side-scrolling concept:
- The player character stays mostly in place horizontally
- Obstacles and background move toward the player
- The player must react quickly to avoid collisions
- Difficulty may increase over time

---

## How the Game Works

### Game Objects

- **Player Character**
  - Controlled by the user
  - Can move up/down or jump (depending on implementation)

- **Obstacles**
  - Move from right to left
  - Must be avoided to continue playing

- **Background**
  - Scrolls continuously to simulate movement

---

### Game Loop

The main game logic runs using a `Timer`:
1. Background elements scroll horizontally
2. Obstacles move toward the player
3. Player input is processed
4. Collision detection checks for crashes
5. Game state updates in real time

---

### Collision Detection

- Collisions are detected using object boundaries
- If the player collides with an obstacle:
  - The game ends
  - A **Game Over** message is displayed

---

## Controls

| Action | Input |
|------|------|
| Move / Jump | Keyboard key (e.g. Spacebar or Arrow keys) |
| Exit game | Close window |

---

## Game Over Condition

- The player collides with an obstacle
- The game timer stops
- A game over message is shown

---

## Visual Feedback

- Smooth scrolling background
- Moving obstacles increase challenge
- Immediate visual response on collision

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: SideScrollingGame/bin/Debug/
2. Run `SideScrollingGame.exe`

### Option 2: Run from Visual Studio
1. Open `SideScrollingGame.sln`
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
- Side-scrolling game mechanics
- Timer-driven animation
- Keyboard input handling
- Collision detection logic

---

## Possible Improvements

- Add scoring based on distance
- Increase scrolling speed over time
- Add enemies or collectibles
- Add sound effects
- Add multiple levels
