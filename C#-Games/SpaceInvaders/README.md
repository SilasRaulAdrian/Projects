# Space Invaders Game

## Overview

**Space Invaders Game** is a classic arcade-style shooter developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a spaceship at the bottom of the screen and must shoot descending alien invaders while avoiding enemy attacks. The objective is to destroy all enemies before they reach the bottom.

This project demonstrates:
- 2D shooter mechanics
- Timer-based game loops
- Keyboard input handling
- Collision detection and scoring logic

---

## Game Concept

The game is inspired by the original **Space Invaders**:
- Aliens move horizontally and gradually descend
- The player shoots enemies from below
- Enemies may shoot back (if implemented)
- The game ends if enemies reach the bottom or the player is hit

---

## How the Game Works

### Game Objects

- **Player Spaceship**
  - Controlled by the user
  - Moves left and right
  - Fires bullets upward

- **Alien Invaders**
  - Move in formation
  - Change direction at screen edges
  - Descend over time

- **Bullets**
  - Fired by the player (and possibly enemies)
  - Destroy targets on collision

---

### Game Loop

The main game logic runs using a `Timer`:
1. Aliens move horizontally across the screen
2. Player input updates ship movement
3. Bullets move vertically
4. Collision detection checks:
   - Bullet vs alien
   - Alien vs player
   - Alien vs bottom boundary
5. Score and game state update continuously

---

### Shooting and Scoring

- When the player shoots an alien:
  - The alien is removed
  - The score increases
- Bullets disappear after hitting a target or leaving the screen

---

## Controls

| Action | Input |
|------|------|
| Move left | Left Arrow key |
| Move right | Right Arrow key |
| Shoot | Spacebar |

---

## Win and Lose Conditions

### Win
- All alien invaders are destroyed
- A victory message is displayed

### Lose
- An alien reaches the bottom of the screen
- The player collides with an enemy or enemy bullet
- A game over message is displayed

---

## Visual Feedback

- Moving alien formations
- Bullet animations
- Clear score and game status display

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: SpaceInvaders/bin/Debug/
2. Run `SpaceInvaders.exe`

### Option 2: Run from Visual Studio
1. Open `SpaceInvaders.sln`
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
- Arcade shooter mechanics
- Managing multiple moving objects
- Collision detection
- Keyboard input and timers in WinForms

---

## Possible Improvements

- Add multiple enemy types
- Increase difficulty over time
- Add sound effects and music
- Add player lives system
- Add power-ups
