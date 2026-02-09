# BreakOut Game

## Overview

**BreakOut Game** is a classic arcade-style game developed using **C# and Windows Forms (.NET Framework 4.7.2)**.  
The objective of the game is to destroy all bricks on the screen by bouncing a ball using a player-controlled paddle. The player must prevent the ball from falling below the paddle while clearing all blocks to win.

This project demonstrates:
- Timer-based game loops
- Collision detection
- Keyboard input handling
- Classic arcade game mechanics in WinForms

---

## Game Concept

The game is inspired by the traditional **Breakout** arcade game:
- A ball moves continuously across the screen
- The player controls a horizontal paddle
- Bricks are destroyed when hit by the ball
- The game ends when all bricks are destroyed or the ball is lost

---

## How the Game Works

### Game Objects

- **Ball**
  - Moves automatically in both X and Y directions
  - Bounces off walls, the paddle, and bricks

- **Paddle**
  - Controlled by the player
  - Used to keep the ball in play

- **Bricks**
  - Arranged in rows at the top of the screen
  - Disappear when hit by the ball

---

### Game Loop

The main game logic runs using a `Timer`:
1. The ball position is updated on every timer tick
2. Collisions are checked:
   - Wall collisions reverse ball direction
   - Paddle collisions bounce the ball upward
   - Brick collisions destroy the brick and change ball direction
3. The game state is updated continuously

---

### Collision Detection

- Collisions are detected using object boundaries
- When the ball intersects:
  - A wall → direction is reversed
  - The paddle → ball bounces upward
  - A brick → brick is removed from the game

---

## Controls

| Action | Input |
|------|------|
| Move paddle left | Left Arrow key |
| Move paddle right | Right Arrow key |

---

## Win and Lose Conditions

### Win
- All bricks are destroyed
- A victory message is displayed

### Lose
- The ball falls below the paddle
- A game over message is displayed

When the game ends, the timer stops and no further input is processed.

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: BreakOut/bin/Debug/
2. Run `BreakOut.exe`

### Option 2: Run from Visual Studio
1. Open `BreakOut.sln`
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
- 2D collision detection
- Timer-driven animation
- Keyboard input handling
- Game logic implementation without a game engine

---

## Possible Improvements

- Add multiple levels
- Increase ball speed over time
- Add lives system
- Add sound effects
- Add score tracking
