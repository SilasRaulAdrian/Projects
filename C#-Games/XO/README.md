# XO Game

## Overview

**XO Game** is a simple turn-based logic game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game is a classic **X and O (Tic Tac Toe)** implementation where two players take turns placing symbols on a grid. The goal is to align symbols in a winning pattern.

This project demonstrates:
- Turn-based gameplay
- Button click event handling
- Win and draw condition checking
- Basic UI state management in WinForms

---

## Game Concept

The XO game follows the classic rules:
- Two players take turns
- One player uses **X**, the other uses **O**
- Players place their symbol on the grid
- The first to complete a winning pattern wins

---

## How the Game Works

### Game Board

- The board is represented by a grid of buttons
- Each button corresponds to one cell
- Once selected, a cell cannot be changed again

---

### Turn Handling

- The game starts with player **X**
- After each move:
  - The turn switches to the other player
- The application tracks the current player internally

---

### Win Detection

After every move, the game checks:
- Horizontal lines
- Vertical lines
- Diagonal lines

If a valid line contains the same symbol:
- The winner is declared
- Input is disabled

---

### Draw Condition

- All cells are filled
- No winning combination exists
- The game ends in a **Draw**

---

## Controls

| Action | Input |
|------|------|
| Place X or O | Left mouse click |
| Restart game | Button (if implemented) |
| Exit game | Close window |

---

## Game Flow

1. The game starts with an empty board
2. Player X makes the first move
3. Players alternate turns
4. The game checks for a winner after each move
5. The game ends with a win or draw

---

## Visual Feedback

- Clear X and O symbols
- Immediate response to user input
- Message shown for win or draw

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: XO/bin/Debug/
2. Run `XO.exe`

### Option 2: Run from Visual Studio
1. Open `XO.sln`
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
- Turn-based game logic
- Conditional checks
- Event-driven UI programming
- Simple game state management

---

## Possible Improvements

- Add single-player mode with AI
- Add score tracking
- Highlight winning combinations
- Add restart/reset functionality
- Improve UI visuals
