# BattleShip

## Overview

**BattleShip** is a classic Battleship-style game developed using **C# and Windows Forms (.NET Framework 4.7.2)**.  
The game simulates a turn-based naval battle where the player attacks hidden enemy ships by clicking on a grid. Each shot can either hit or miss a ship, and the objective is to destroy all enemy ships.

This project demonstrates:
- Windows Forms UI design
- Event-driven programming
- Grid-based game logic
- Basic game state management

---

## Game Concept

The game is based on the traditional **Battleship** rules:
- Enemy ships are placed on a hidden grid
- The player fires shots by clicking on grid cells
- Hits and misses are visually represented
- The game ends when all ships are destroyed

---

## How the Game Works

### Game Board

- The board is represented using a grid of buttons
- Each button corresponds to a position on the battlefield
- Ships are placed programmatically and are hidden from the player

---

### Player Actions

- The player clicks on a grid cell to fire a shot
- Each click represents one attack attempt
- Once a cell is clicked, it cannot be clicked again

---

### Hit and Miss Logic

- **Hit**:
  - The cell changes its image to a fire icon
  - The internal ship counter is decreased
- **Miss**:
  - The cell changes its image to a miss icon

The game keeps track of all shots and updates the board accordingly.

---

### Game State Management

- The game checks after every hit if all ships have been destroyed
- When no ships remain:
  - A victory message is displayed
  - The game stops accepting further input

---

## Controls

| Action | Input |
|------|------|
| Fire at a position | Left mouse click |
| Continue playing | Automatic |
| End game | When all ships are destroyed |

---

## Visual Feedback

The game uses image resources to indicate results:
- **Fire icon** -> successful hit
- **Miss icon** -> missed shot
- **Background image** -> game board background

These visuals make the game state clear and intuitive.

---
## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: BattleShip/BattleShip/bin/Debug/
2. Run `BattleShip.exe`

### Option 2: Run from Visual Studio
1. Open `BattleShip.sln`
2. Build the solution
3. Press **F5** to start the game

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for editing and development)

---

## Educational Purpose

This project is suitable for learning:
- Grid-based logic in WinForms
- Handling button click events
- Managing game state without a game engine
- Using resources (images) in desktop applications

---

## Possible Improvements

- Add multiple ship sizes
- Add a score or turn counter
- Implement an AI opponent
- Add sound effects
- Add a restart or reset button
