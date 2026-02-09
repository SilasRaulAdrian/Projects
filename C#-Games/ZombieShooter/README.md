# Zombie Shooter Game

## Overview

**Zombie Shooter Game** is a simple 2D shooter game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a character that must survive waves of zombies by shooting them before they reach the player. The game focuses on fast reactions, shooting mechanics, and basic enemy behavior.

This project demonstrates:
- 2D shooter mechanics
- Timer-based game loops
- Keyboard and mouse input handling
- Collision detection and scoring logic

---

## Game Concept

The game is based on a classic zombie survival scenario:
- Zombies spawn and move toward the player
- The player shoots zombies to survive
- Each destroyed zombie increases the score
- The game ends if a zombie reaches the player

---

## How the Game Works

### Game Objects

- **Player**
  - Controlled by the user
  - Can move (if implemented)
  - Shoots bullets toward zombies

- **Zombies**
  - Spawn at random positions
  - Move toward the player
  - Cause game over on collision

- **Bullets**
  - Fired by the player
  - Destroy zombies on collision

---

### Game Loop

The main game logic runs using a `Timer`:
1. Zombies move toward the player
2. Player input is processed
3. Bullets move across the screen
4. Collision detection checks:
   - Bullet vs zombie
   - Zombie vs player
5. Score and game state update continuously

---

### Shooting and Scoring

- When a bullet hits a zombie:
  - The zombie is removed
  - The score increases
- Bullets disappear after collision or leaving the screen

---

## Controls

| Action | Input |
|------|------|
| Move player | Arrow keys / WASD (if implemented) |
| Shoot | Mouse click or Spacebar |
| Exit game | Close window |

---

## Game Over Condition

- A zombie collides with the player
- The game timer stops
- A game over message is displayed

---

## Visual Feedback

- Zombie movement toward the player
- Bullet animations
- Real-time score display
- Immediate feedback on collisions

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: ZombieShooter/bin/Debug/
2. Run `ZombieShooter.exe`

### Option 2: Run from Visual Studio
1. Open `ZombieShooter.sln`
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
- Shooter game mechanics
- Enemy spawning and movement
- Collision detection
- Timer-driven gameplay in WinForms

---

## Possible Improvements

- Add multiple zombie types
- Increase difficulty over time
- Add player health system
- Add sound effects and music
- Add restart or level system
