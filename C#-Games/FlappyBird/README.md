# Flappy Bird Game

## Overview

**Flappy Bird Game** is a simple 2D arcade-style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a bird and must navigate it through gaps between moving pipes without colliding. The game tests timing, precision, and quick reaction skills.

This project demonstrates:
- Timer-based game loops
- Gravity and movement mechanics
- Collision detection
- Keyboard input handling in WinForms

---

## Game Concept

The game is inspired by the classic **Flappy Bird**:
- The bird continuously falls due to gravity
- The player makes the bird jump to avoid obstacles
- Pipes move horizontally across the screen
- The goal is to survive as long as possible

---

## How the Game Works

### Game Objects

- **Bird**
  - Controlled by the player
  - Affected by gravity
  - Can jump upward when input is given

- **Pipes**
  - Move from right to left
  - Have gaps the bird must pass through
  - Reset position after leaving the screen

- **Ground**
  - Acts as a collision boundary
  - Hitting it ends the game

---

### Game Loop

The main game logic runs using a `Timer`:
1. Gravity pulls the bird downward
2. Pipes move horizontally across the screen
3. Collision detection is performed
4. The score and game state update continuously

---

### Jump Mechanics

- When the player presses the jump key:
  - An upward force is applied to the bird
  - Gravity resumes immediately after

---

### Collision Detection

- Collision occurs if:
  - The bird hits a pipe
  - The bird hits the ground
- Any collision results in **Game Over**

---

## Controls

| Action | Input |
|------|------|
| Jump / Fly up | Spacebar |
| Exit game | Close window |

---

## Game Over Condition

- The bird collides with an obstacle or the ground
- The game timer stops
- A game over message is displayed

---

## Visual Feedback

- Smooth pipe movement
- Clear collision boundaries
- Immediate response to player input

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: FlappyBird/bin/Debug/
2. Run `FlappyBird.exe`

### Option 2: Run from Visual Studio
1. Open `FlappyBird.sln`
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
- Gravity-based movement
- Continuous animation with timers
- Collision detection
- Arcade game logic in WinForms

---

## Possible Improvements

- Add score tracking
- Add sound effects
- Increase pipe speed over time
- Add restart functionality
- Add animations
