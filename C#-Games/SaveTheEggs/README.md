# Save The Eggs Game

## Overview

**Save The Eggs** is a simple 2D arcade-style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The objective of the game is to catch falling eggs before they hit the ground. The player must move a basket horizontally to save as many eggs as possible.

This project demonstrates:
- Timer-based game loops
- Keyboard or mouse input handling
- Falling object mechanics
- Collision detection in WinForms

---

## Game Concept

The game is based on a classic catching mechanic:
- Eggs fall from the top of the screen
- The player controls a basket at the bottom
- Eggs must be caught before they fall to the ground
- Missing eggs may end the game or reduce lives

---

## How the Game Works

### Game Objects

- **Eggs**
  - Spawn at random horizontal positions
  - Fall vertically toward the bottom of the screen

- **Basket**
  - Controlled by the player
  - Moves left and right to catch eggs

- **Ground / Bottom Area**
  - Eggs that reach this area are considered missed

---

### Game Loop

The main game logic runs using a `Timer`:
1. Eggs move downward every tick
2. Player input moves the basket
3. Collision detection checks:
   - Egg vs basket
   - Egg vs ground
4. Game state updates continuously

---

### Catching Logic

- When an egg collides with the basket:
  - The egg is considered saved
  - The score increases
  - The egg is repositioned at the top

- When an egg hits the ground:
  - The egg is lost
  - The game may end or reduce remaining lives

---

## Controls

| Action | Input |
|------|------|
| Move basket left | Left Arrow key |
| Move basket right | Right Arrow key |
| Exit game | Close window |

---

## Game Over Condition

- One or more eggs fall to the ground (depending on rules)
- The game timer stops
- A game over message is displayed

---

## Visual Feedback

- Falling egg animations
- Basket movement
- Score or lives displayed on screen

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: SaveTheEggs/bin/Debug/
2. Run `SaveTheEggs.exe`

### Option 2: Run from Visual Studio
1. Open `SaveTheEggs.sln`
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
- Falling object mechanics
- Collision detection
- Timer-driven animation
- Keyboard input handling

---

## Possible Improvements

- Add multiple eggs at once
- Increase falling speed over time
- Add lives system
- Add sound effects
- Add restart functionality
