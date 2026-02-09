# Multiple Levels Game

## Overview

**Multiple Levels Game** is a simple 2D arcade-style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game features multiple levels with increasing difficulty, where the player must complete objectives in each level in order to progress to the next one.

This project demonstrates:
- Level-based game structure
- Timer-based game loops
- Game state and level management
- Event-driven programming in WinForms

---

## Game Concept

The game is structured around multiple stages:
- Each level introduces new challenges or increased difficulty
- The player must complete the current level to unlock the next one
- Difficulty may increase through speed, obstacles, or complexity

---

## How the Game Works

### Level System

- The game is divided into multiple levels
- Each level:
  - Has its own configuration (speed, obstacles, objectives)
  - Ends when the level objective is completed
- After completing a level:
  - The game advances automatically to the next level

---

### Game Objects

Depending on the level, the game may include:
- **Player character**
- **Obstacles or enemies**
- **Targets or goals**

Objects behave differently based on the active level settings.

---

### Game Loop

The main game logic runs using a `Timer`:
1. Game objects are updated every tick
2. Player input is processed
3. Collisions or objectives are checked
4. The level state is evaluated

---

### Level Progression

- When a level objective is met:
  - The timer pauses briefly
  - The next level is initialized
- If the player fails:
  - The game may restart the level or end

---

## Controls

| Action | Input |
|------|------|
| Move / Control player | Keyboard input |
| Interact / Action | Key or mouse (depending on level) |
| Exit game | Close window |

---

## Game Flow

1. The game starts at Level 1
2. The player completes the level objective
3. The game transitions to the next level
4. Difficulty increases with each level
5. The game ends after the final level or on failure

---

## Visual Feedback

- Level indicators (Level 1, Level 2, etc.)
- Dynamic changes between levels
- Clear feedback for level completion

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: MultipleLevelsGame/bin/Debug/
2. Run `MultipleLevelsGame.exe`

### Option 2: Run from Visual Studio
1. Open `MultipleLevelsGame.sln`
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
- Level-based game design
- Managing game states
- Increasing difficulty mechanics
- Structuring larger WinForms projects

---

## Possible Improvements

- Add level selection menu
- Save player progress
- Add animations and sound effects
- Add checkpoints
- Improve level variety
