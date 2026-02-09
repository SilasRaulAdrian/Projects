# BalloonPop

## Overview

**BalloonPop** is a simple 2D arcade-style game developed using **C# and Windows Forms (.NET Framework 4.7.2)**.  
The main goal of the game is to pop balloons by clicking on them before they reach the top of the screen, while avoiding the bomb. As the player scores more points, the game speed increases, making it more challenging over time.

This project is designed as a beginner-friendly example of:
- Windows Forms event-driven programming
- Using timers as a basic game loop
- Handling user input (mouse and keyboard)
- Simple collision detection and game state management

---

## How the Game Works

### Game Objects

The game uses multiple `PictureBox` components:
- **Balloons** – clickable objects that increase the score
- **Bomb** – an object that ends the game instantly if clicked
- **Decorative elements** – stars, hearts, and other visuals for variation

All objects are positioned randomly and move vertically on the screen.

---

### Game Loop (Timer-Based Logic)

The core logic runs inside a `Timer` event (`gameTimer_Tick`):

1. On every timer tick:
   - All game objects move upward based on the current speed
   - Objects that exit the top of the screen are repositioned at the bottom
   - The score label is updated

2. Difficulty increases dynamically:
   - Score > 5 -> speed increases
   - Score >= 15 -> speed increases further
   - Score >= 25 -> maximum speed is reached

---

### Balloon Behavior

- Balloons can be popped by clicking on them
- When a balloon is clicked:
  - It is repositioned at the bottom of the screen
  - The score increases by 1
- If a balloon reaches the top of the screen without being clicked, the game ends

---

### Bomb Behavior

- Clicking the bomb:
  - Changes its image to an explosion
  - Immediately triggers **Game Over**
- If the bomb collides with another object:
  - The other object is reset
  - No score is added

---

### Game Over State

When the game ends:
- The timer stops
- The score label displays a “Game Over” message
- The game waits for player input to restart

---

## Controls

| Action | Input |
|------|------|
| Pop a balloon | Left mouse click |
| Click the bomb | Left mouse click |
| Restart the game | Enter key |

---

## Restarting the Game

After a Game Over, pressing **Enter**:
- Resets the score to 0
- Resets the game speed
- Repositions all objects randomly
- Restores the bomb image
- Restarts the game timer

---
## How to Run the Game

### Run the Executable
1. Open:
2. Run `BalloonPop.exe`

### Run from Visual Studio
1. Open `BalloonPop.sln`
2. Build the solution
3. Press **F5** to start the game

---

## Requirements

- Windows operating system
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project demonstrates:
- Basic game development without a game engine
- Timer-based animation
- Mouse and keyboard event handling
- Simple difficulty scaling
