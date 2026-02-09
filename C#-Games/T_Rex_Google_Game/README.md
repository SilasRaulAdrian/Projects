# T-Rex Google Game

## Overview

**T-Rex Google Game** is a simple 2D endless runner game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game is inspired by the well-known Google Chrome offline dinosaur game. The player controls a dinosaur that must jump over obstacles and survive for as long as possible.

This project demonstrates:
- Endless runner mechanics
- Timer-based game loops
- Keyboard input handling
- Collision detection in WinForms

---

## Game Concept

The game follows a classic endless runner design:
- The dinosaur runs automatically
- Obstacles move toward the player
- The player must jump to avoid collisions
- The game speed may increase over time

The goal is to survive as long as possible without hitting obstacles.

---

## How the Game Works

### Game Objects

- **T-Rex (Player)**
  - Controlled by the user
  - Can jump to avoid obstacles
  - Affected by gravity

- **Obstacles**
  - Appear from the right side of the screen
  - Move left toward the player
  - Respawn after leaving the screen

- **Ground**
  - Acts as the running surface
  - Prevents the player from falling

---

### Game Loop

The main game logic runs using a `Timer`:
1. Obstacles move from right to left
2. Gravity affects the T-Rex position
3. Player input triggers jumping
4. Collision detection checks:
   - T-Rex vs obstacles
5. Game state updates continuously

---

### Jump and Gravity Mechanics

- Gravity constantly pulls the T-Rex downward
- When the jump key is pressed:
  - An upward force is applied
  - The T-Rex jumps and then falls back to the ground
- Jumping is disabled while the T-Rex is already in the air

---

### Collision Detection

- If the T-Rex collides with an obstacle:
  - The game ends
  - The timer stops
  - A **Game Over** message is displayed

---

## Controls

| Action | Input |
|------|------|
| Jump | Spacebar |
| Exit game | Close window |

---

## Game Over Condition

- The T-Rex collides with an obstacle
- The game stops immediately
- A game over message is shown

---

## Visual Feedback

- Smooth obstacle movement
- Clear jump animation
- Immediate response to player input

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: TRexGame/bin/Debug/
2. Run `TRexGame.exe`

### Option 2: Run from Visual Studio
1. Open `TRexGame.sln`
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
- Endless runner mechanics
- Gravity and jump physics
- Collision detection
- Timer-based animation in WinForms

---

## Possible Improvements

- Add score based on survival time
- Increase obstacle speed over time
- Add different obstacle types
- Add sound effects
- Add restart functionality
