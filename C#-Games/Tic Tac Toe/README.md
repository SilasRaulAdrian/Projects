# Tic Tac Toe Game

## Overview

**Tic Tac Toe Game** is a simple turn-based logic game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game allows two players (or a player against basic logic) to play the classic Tic Tac Toe game on a 3×3 grid.

This project demonstrates:
- Turn-based game logic
- Button click event handling
- Win condition checking
- Basic UI state management in WinForms

---

## Game Concept

The game follows the traditional **Tic Tac Toe** rules:
- Two players take turns
- One player uses **X**, the other uses **O**
- Players place their symbol on a 3×3 grid
- The first player to align three symbols wins

---

## How the Game Works

### Game Board

- The board consists of a **3×3 grid of buttons**
- Each button represents one cell
- Once clicked, a cell cannot be changed again

---

### Turn Logic

- The game starts with Player X
- After each valid move:
  - The turn switches to the other player
- The game tracks whose turn it is internally

---

### Win Detection

After every move, the game checks:
- Horizontal combinations
- Vertical combinations
- Diagonal combinations

If three identical symbols are aligned:
- The game declares a winner
- Further input is disabled

---

### Draw Condition

- If all cells are filled
- And no winning combination is found
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

1. The game starts with an empty grid
2. Player X makes the first move
3. Players alternate turns
4. The game checks for a win after each move
5. The game ends with a win or draw

---

## Visual Feedback

- X and O symbols displayed clearly
- Immediate response to player input
- Message displayed for win or draw

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: TicTacToe/bin/Debug/
2. Run `TicTacToe.exe`

### Option 2: Run from Visual Studio
1. Open `TicTacToe.sln`
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
- Turn-based logic
- Condition checking
- UI event handling
- Simple game state management

---

## Possible Improvements

- Add single-player mode with AI
- Add score tracking
- Highlight winning line
- Add restart button
- Improve UI design
