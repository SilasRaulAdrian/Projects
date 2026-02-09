# Sliding Image Puzzle Game

## Overview

**Sliding Image Puzzle** is a classic logic-based puzzle game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The objective of the game is to rearrange scrambled image tiles to restore the original image by sliding tiles into an empty space.

This project demonstrates:
- Puzzle game logic
- Image slicing and positioning
- Event-driven programming in WinForms
- Game state validation

---

## Game Concept

The game is based on the traditional sliding puzzle:
- An image is divided into multiple tiles
- One tile position is left empty
- Tiles can be moved only into the empty space
- The puzzle is solved when all tiles are in the correct order

---

## How the Game Works

### Puzzle Setup

- At the start of the game:
  - An image is split into equal-sized tiles
  - Tiles are shuffled randomly
  - One tile position remains empty

---

### Tile Movement Logic

- The player clicks on a tile
- If the tile is adjacent to the empty space:
  - The tile slides into the empty position
- If the tile is not adjacent:
  - No movement occurs

---

### Win Condition Check

- After each move:
  - The game checks if all tiles are in the correct position
- When the puzzle is solved:
  - A victory message is displayed
  - The game stops accepting input

---

## Controls

| Action | Input |
|------|------|
| Move tile | Left mouse click |
| Exit game | Close window |

---

## Game Flow

1. The puzzle is displayed in a scrambled state
2. The player moves tiles by clicking
3. Tiles slide into the empty space
4. The game checks for completion after each move
5. The game ends when the image is correctly restored

---

## Visual Feedback

- Smooth tile movement
- Clear visual representation of the image
- Immediate response to player actions

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: SlidingImagePuzzle/bin/Debug/
2. Run `SlidingImagePuzzle.exe`

### Option 2: Run from Visual Studio
1. Open `SlidingImagePuzzle.sln`
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
- Puzzle-solving logic
- Managing grid-based layouts
- Event handling
- Image manipulation in WinForms

---

## Possible Improvements

- Add different puzzle sizes (3×3, 4×4)
- Add move counter
- Add timer
- Allow user-selected images
- Add shuffle difficulty levels
