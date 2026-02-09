# Pac-Man Game

## Overview

**Pac-Man Game** is a classic arcade-style game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player controls Pac-Man, navigating through a maze, collecting pellets while avoiding enemy ghosts. The objective is to collect all pellets without being caught.

This project demonstrates:
- Grid-based movement
- Timer-based game loops
- Collision detection
- Classic arcade game mechanics in WinForms

---

## Game Concept

The game is inspired by the original **Pac-Man**:
- Pac-Man moves through a maze
- Pellets are scattered throughout the level
- Ghosts move around the maze as enemies
- The player must avoid ghosts and collect all pellets to win

---

## How the Game Works

### Game Objects

- **Pac-Man**
  - Controlled by the player
  - Moves in four directions
  - Collects pellets

- **Pellets**
  - Small collectible items
  - Increase progress when collected
  - All must be collected to win

- **Ghosts**
  - Move automatically
  - Cause game over on collision with Pac-Man

- **Walls**
  - Define the maze structure
  - Block movement

---

### Game Loop

The main game logic runs using a `Timer`:
1. Player movement is processed
2. Ghosts move automatically
3. Collision detection checks:
   - Pac-Man vs pellets
   - Pac-Man vs ghosts
4. The game state updates continuously

---

### Collision Detection

- **Pac-Man & Pellet**:
  - Pellet is removed
- **Pac-Man & Ghost**:
  - Game Over
- **Pac-Man & Wall**:
  - Movement is blocked

---

## Controls

| Action | Input |
|------|------|
| Move up | Up Arrow key |
| Move down | Down Arrow key |
| Move left | Left Arrow key |
| Move right | Right Arrow key |

---

## Win and Lose Conditions

### Win
- All pellets are collected
- A victory message is displayed

### Lose
- Pac-Man collides with a ghost
- A game over message is displayed

---

## Visual Feedback

- Clear maze layout
- Animated character movement
- Immediate response to collisions

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: PacMan/bin/Debug/
2. Run `PacMan.exe`

### Option 2: Run from Visual Studio
1. Open `PacMan.sln`
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
- Grid-based movement systems
- Enemy AI basics
- Collision detection
- Classic game recreation in WinForms

---

## Possible Improvements

- Add multiple levels
- Implement power pellets
- Improve ghost AI
- Add score tracking
- Add sound effects
