# Colour Switch Game

## Overview

**Colour Switch Game** is a simple reflex-based arcade game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The objective of the game is to guide a ball through rotating obstacles by matching its color with the correct obstacle segment. The player must react quickly and precisely to survive.

This project demonstrates:
- Timer-based animation
- Color-based collision logic
- Keyboard or mouse input handling
- Basic arcade game mechanics in WinForms

---

## Game Concept

The game is inspired by the popular **Colour Switch** concept:
- A ball moves vertically through the screen
- Obstacles rotate continuously
- Each obstacle is divided into colored segments
- The ball can pass only through segments that match its current color

---

## How the Game Works

### Game Objects

- **Ball**
  - Has a specific color
  - Moves upward or downward depending on input

- **Obstacles**
  - Rotating shapes divided into multiple colors
  - Positioned at different heights on the screen

- **Color Switchers**
  - Change the ball’s color when touched

---

### Game Loop

The game logic runs using a `Timer`:
1. Obstacles rotate continuously
2. The ball position is updated
3. Collision detection is performed
4. Color matching logic determines survival or failure

---

### Collision Logic

- When the ball touches an obstacle:
  - If colors match → the ball passes safely
  - If colors do not match → **Game Over**
- When the ball touches a color switcher:
  - The ball’s color changes randomly

---

## Controls

| Action | Input |
|------|------|
| Move / Jump | Spacebar or mouse click |
| Exit game | Close window |

---

## Game Over Condition

- The ball touches an obstacle with a different color
- The game stops immediately
- A game over message is displayed

---

## Visual Feedback

- Smooth rotating obstacles
- Clear color contrasts
- Immediate visual response on collision

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: ColourSwitch/bin/Debug/
2. Run `ColourSwitch.exe`

### Option 2: Run from Visual Studio
1. Open `ColourSwitch.sln`
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
- Color-based collision logic
- Timers for animation
- Event handling in WinForms
- Reflex-based game design

---

## Possible Improvements

- Add score tracking
- Add multiple obstacle types
- Increase difficulty over time
- Add sound effects
- Add restart functionality
