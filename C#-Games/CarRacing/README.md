# Car Racing Game

## Overview

**Car Racing Game** is a simple 2D racing game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a car and must avoid incoming obstacles while driving forward on a scrolling road. The game tests the player’s reaction time and coordination.

This project demonstrates:
- Timer-based game loops
- Keyboard input handling
- Collision detection
- Continuous background movement in WinForms

---

## Game Concept

The game simulates a top-down car racing experience:
- The road scrolls vertically to simulate movement
- Enemy cars or obstacles appear from the top
- The player must avoid collisions
- The game ends when the player crashes

---

## How the Game Works

### Game Objects

- **Player Car**
  - Controlled by the user
  - Can move left and right on the road

- **Enemy Cars / Obstacles**
  - Move downward toward the player
  - Respawn at the top after leaving the screen

- **Road / Background**
  - Scrolls continuously to create a driving effect

---

### Game Loop

The main game logic runs using a `Timer`:
1. The road background scrolls downward
2. Enemy cars move toward the player
3. Collision detection is performed
4. The game state updates continuously

---

### Collision Detection

- Collision is detected using object boundaries
- If the player car intersects with an enemy car:
  - The timer stops
  - A **Game Over** message is displayed

---

## Controls

| Action | Input |
|------|------|
| Move left | Left Arrow key |
| Move right | Right Arrow key |

---

## Game Over Condition

- The player collides with an enemy car
- The game stops immediately
- A game over message is shown

---

## Visual Feedback

- Scrolling road gives a sense of speed
- Enemy cars increase challenge
- Clear visual separation between player and obstacles

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: CarRacing/bin/Debug/
2. Run `CarRacing.exe`

### Option 2: Run from Visual Studio
1. Open `CarRacing.sln`
2. Build the solution
3. Press **F5** to start the game

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project helps in learning:
- Keyboard-based movement
- Collision detection
- Timer-driven animation
- Game logic without a game engine

---

## Possible Improvements

- Add score based on distance
- Increase speed over time
- Add multiple lanes
- Add sound effects
- Add restart button
