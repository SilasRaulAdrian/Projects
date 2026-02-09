# Gravity Run Game

## Overview

**Gravity Run Game** is a simple 2D endless runner–style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a character that runs automatically while gravity can be switched to avoid obstacles and survive for as long as possible.

This project demonstrates:
- Gravity manipulation mechanics
- Timer-based game loops
- Keyboard input handling
- Collision detection in WinForms

---

## Game Concept

The game is based on a gravity-switching runner concept:
- The character moves continuously forward
- Obstacles appear along the path
- The player can switch gravity to run on the ceiling or the ground
- The objective is to survive as long as possible without colliding

---

## How the Game Works

### Game Objects

- **Player Character**
  - Moves automatically
  - Affected by gravity
  - Can switch gravity direction

- **Obstacles**
  - Appear in the player’s path
  - Must be avoided using gravity changes

- **Ground and Ceiling**
  - Act as surfaces where the player can run
  - Change based on gravity direction

---

### Game Loop

The main game logic runs using a `Timer`:
1. The environment scrolls horizontally
2. Obstacles move toward the player
3. Gravity affects the player’s vertical position
4. Collision detection checks for crashes

---

### Gravity Switching Mechanic

- When the player presses the gravity switch key:
  - Gravity direction is inverted
  - The player moves toward the opposite surface
- Timing is critical to avoid obstacles

---

### Collision Detection

- A collision occurs when:
  - The player hits an obstacle
- On collision:
  - The game timer stops
  - A **Game Over** message is displayed

---

## Controls

| Action | Input |
|------|------|
| Switch gravity | Spacebar |
| Exit game | Close window |

---

## Game Over Condition

- The player collides with an obstacle
- The game stops immediately
- A game over message is shown

---

## Visual Feedback

- Smooth movement of obstacles
- Clear gravity transitions
- Immediate response to player input

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: GravityRun/bin/Debug/
2. Run `GravityRun.exe`

### Option 2: Run from Visual Studio
1. Open `GravityRun.sln`
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
- Gravity-based mechanics
- Continuous movement and scrolling
- Collision detection
- Game logic implementation without a game engine

---

## Possible Improvements

- Add score based on survival time
- Increase speed over time
- Add different obstacle types
- Add sound effects
- Add restart functionality
