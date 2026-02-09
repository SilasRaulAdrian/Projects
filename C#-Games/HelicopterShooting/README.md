# Helicopter Shooting Game

## Overview

**Helicopter Shooting Game** is a simple 2D arcade shooter developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a helicopter and must shoot enemies while avoiding collisions. The game emphasizes fast reactions, shooting accuracy, and basic movement mechanics.

This project demonstrates:
- Timer-based game loops
- Keyboard input handling
- Shooting and projectile logic
- Collision detection in WinForms

---

## Game Concept

The game simulates a helicopter combat scenario:
- The player controls a helicopter on the screen
- Enemies appear and move toward the player
- The helicopter can shoot bullets to destroy enemies
- The game ends if the helicopter collides with an enemy

---

## How the Game Works

### Game Objects

- **Player Helicopter**
  - Controlled by the user
  - Can move vertically and horizontally
  - Can fire bullets

- **Enemies**
  - Move across the screen toward the player
  - Respawn after being destroyed or leaving the screen

- **Bullets**
  - Fired by the helicopter
  - Travel in a straight line
  - Destroy enemies on collision

---

### Game Loop

The main game logic runs using a `Timer`:
1. Enemy objects move continuously
2. Bullets move forward
3. Collision detection checks:
   - Bullet vs enemy
   - Helicopter vs enemy
4. The game state updates in real time

---

### Shooting Mechanics

- When the player presses the shoot key:
  - A bullet is created at the helicopter’s position
  - The bullet moves forward on each timer tick
- Bullet–enemy collisions remove the enemy and the bullet

---

### Collision Detection

- **Bullet–Enemy Collision**:
  - Enemy is destroyed
- **Helicopter–Enemy Collision**:
  - Triggers **Game Over**
  - The game timer stops

---

## Controls

| Action | Input |
|------|------|
| Move up | Up Arrow key |
| Move down | Down Arrow key |
| Move left | Left Arrow key |
| Move right | Right Arrow key |
| Shoot | Spacebar |

---

## Game Over Condition

- The helicopter collides with an enemy
- The game stops immediately
- A game over message is displayed

---

## Visual Feedback

- Bullet animations for shooting
- Enemy movement increases difficulty
- Clear player–enemy distinction

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: HelicopterShooting/bin/Debug/
2. Run `HelicopterShooting.exe`

### Option 2: Run from Visual Studio
1. Open `HelicopterShooting.sln`
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
- 2D shooter mechanics
- Projectile management
- Timer-driven animation
- Collision detection in WinForms

---

## Possible Improvements

- Add score tracking
- Add multiple enemy types
- Increase difficulty over time
- Add sound effects
- Add restart functionality
