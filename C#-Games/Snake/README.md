# Snake Game

## Overview

**Snake Game** is a classic arcade-style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls a snake that moves around the screen, eats food to grow longer, and must avoid colliding with walls or its own body.

This project demonstrates:
- Grid-based movement
- Timer-based game loops
- Keyboard input handling
- Collision detection and game state management

---

## Game Concept

The game follows the traditional **Snake** mechanics:
- The snake moves continuously in one direction
- The player changes direction using the keyboard
- Eating food increases the snake’s length
- The game ends if the snake hits a wall or itself

---

## How the Game Works

### Game Objects

- **Snake**
  - Composed of multiple segments
  - Moves one grid cell at a time
  - Grows when food is eaten

- **Food**
  - Appears at random positions on the grid
  - Causes the snake to grow when eaten

- **Walls / Boundaries**
  - Define the playable area
  - Colliding with them ends the game

---

### Game Loop

The main game logic runs using a `Timer`:
1. The snake moves in the current direction
2. Keyboard input updates the direction
3. Collision detection checks:
   - Snake vs food
   - Snake vs walls
   - Snake vs itself
4. The game state updates continuously

---

### Growth and Scoring

- When the snake eats food:
  - A new segment is added to the tail
  - The score increases
  - New food spawns at a random location

---

## Controls

| Action | Input |
|------|------|
| Move up | Up Arrow key |
| Move down | Down Arrow key |
| Move left | Left Arrow key |
| Move right | Right Arrow key |

---

## Game Over Condition

- The snake collides with:
  - The wall, or
  - Its own body
- The game timer stops
- A game over message is displayed

---

## Visual Feedback

- Clear grid-based movement
- Visible snake growth
- Immediate response to player input

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: Snake/bin/Debug/
2. Run `Snake.exe`

### Option 2: Run from Visual Studio
1. Open `Snake.sln`
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
- Grid-based game logic
- Collision detection
- Keyboard input handling
- Managing dynamic game objects

---

## Possible Improvements

- Increase speed as the snake grows
- Add levels or obstacles
- Add high-score saving
- Add pause / resume functionality
- Improve graphics and animations
