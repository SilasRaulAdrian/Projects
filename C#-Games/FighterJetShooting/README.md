# Fighter Jet Shooting Game

## Overview

**Fighter Jet Shooting Game** is a simple 2D arcade-style shooter developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a fighter jet and must shoot incoming enemies while avoiding collisions. The game focuses on fast reactions, shooting mechanics, and basic collision detection.

This project demonstrates:
- Timer-based game loops
- Keyboard input handling
- Projectile (bullet) management
- Collision detection in WinForms

---

## Game Concept

The game simulates an aerial combat scenario:
- The player controls a fighter jet at the bottom of the screen
- Enemy objects move toward the player
- The player fires bullets to destroy enemies
- The game ends when the player collides with an enemy

---

## How the Game Works

### Game Objects

- **Player Jet**
  - Controlled by the user
  - Can move horizontally
  - Can fire bullets upward

- **Enemies**
  - Move downward toward the player
  - Respawn after being destroyed or leaving the screen

- **Bullets**
  - Fired by the player
  - Travel upward
  - Destroy enemies on collision

---

### Game Loop

The main game logic runs using a `Timer`:
1. Enemy objects move downward
2. Bullets move upward
3. Collision detection is performed
4. The game state updates continuously

---

### Shooting Mechanics

- When the player fires:
  - A bullet object is created
  - The bullet moves upward each timer tick
- When a bullet collides with an enemy:
  - The enemy is removed or reset
  - The bullet disappears

---

### Collision Detection

- Bullet–enemy collisions destroy enemies
- Player–enemy collisions trigger **Game Over**
- Collision checks are based on object boundaries

---

## Controls

| Action | Input |
|------|------|
| Move left | Left Arrow key |
| Move right | Right Arrow key |
| Shoot | Spacebar |

---

## Game Over Condition

- The player jet collides with an enemy
- The game timer stops
- A game over message is displayed

---

## Visual Feedback

- Bullet animations indicate shooting
- Enemy movement increases difficulty
- Clear separation between player, enemies, and projectiles

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: FighterJetShooting/bin/Debug/
2. Run `FighterJetShooting.exe`

### Option 2: Run from Visual Studio
1. Open `FighterJetShooting.sln`
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
- Shooting mechanics in 2D games
- Timer-based animations
- Keyboard input handling
- Collision detection logic

---

## Possible Improvements

- Add multiple enemy types
- Add score tracking
- Increase difficulty over time
- Add sound effects
- Add restart functionality
