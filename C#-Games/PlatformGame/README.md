# Platform Game

## Overview

**Platform Game** is a simple 2D platformer developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a character that can move and jump across platforms, avoid obstacles, and reach the end of the level. The game focuses on classic platformer mechanics such as gravity, jumping, and collision detection.

This project demonstrates:
- Platformer movement mechanics
- Gravity and jumping logic
- Collision detection with platforms
- Timer-based game loops in WinForms

---

## Game Concept

The game follows a classic platformer structure:
- The player navigates through a level made of platforms
- Gravity constantly pulls the player downward
- The player must jump between platforms to progress
- Falling off the level or hitting obstacles may end the game

---

## How the Game Works

### Game Objects

- **Player Character**
  - Controlled by the user
  - Can move left and right
  - Can jump when on a platform

- **Platforms**
  - Static objects the player can stand on
  - Prevent the player from falling due to gravity

- **Obstacles / Hazards** (if present)
  - Cause the player to lose or restart the level on collision

---

### Game Loop

The main game logic runs using a `Timer`:
1. Gravity is applied to the player
2. Player movement input is processed
3. Collision detection checks:
   - Player vs platforms
   - Player vs obstacles
4. The game state updates continuously

---

### Jumping and Gravity

- Gravity pulls the player downward every frame
- When the player presses the jump key:
  - An upward force is applied
  - Jumping is only allowed when the player is on a platform

---

### Collision Detection

- Platform collisions stop downward movement
- Side collisions prevent passing through platforms
- Falling below the level or hitting hazards may trigger **Game Over**

---

## Controls

| Action | Input |
|------|------|
| Move left | Left Arrow key |
| Move right | Right Arrow key |
| Jump | Spacebar |

---

## Win and Lose Conditions

### Win
- The player reaches the end of the level (if implemented)

### Lose
- The player falls off the level or hits an obstacle
- A game over or restart occurs

---

## Visual Feedback

- Clear platform layout
- Smooth character movement
- Immediate response to input and collisions

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: PlatformGame/bin/Debug/
2. Run `PlatformGame.exe`

### Option 2: Run from Visual Studio
1. Open `PlatformGame.sln`
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
- Gravity and jump mechanics
- Platform collision detection
- Timer-driven game loops
- Basic platformer game design

---

## Possible Improvements

- Add multiple levels
- Add enemies
- Add collectibles and scoring
- Add sound effects
- Improve animations
