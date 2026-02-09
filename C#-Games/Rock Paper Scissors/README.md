# Rock Paper Scissors Game

## Overview

**Rock Paper Scissors Game** is a simple desktop game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game allows the player to compete against the computer in the classic Rock–Paper–Scissors game, where each round produces a win, loss, or draw.

This project demonstrates:
- Random choice generation
- Conditional game logic
- Event-driven programming
- Simple score tracking in WinForms

---

## Game Concept

The game follows the traditional Rock–Paper–Scissors rules:
- Rock beats Scissors
- Scissors beats Paper
- Paper beats Rock

The player selects one option, the computer selects another randomly, and the result is displayed.

---

## How the Game Works

### Player Choice

- The player selects one of the following options:
  - Rock
  - Paper
  - Scissors
- Selection is done via buttons or clickable controls

---

### Computer Choice

- The computer randomly selects one option
- The choice is generated each round using a random number generator

---

### Result Evaluation

- The game compares the player’s choice with the computer’s choice
- Possible outcomes:
  - **Win**
  - **Lose**
  - **Draw**
- The result is displayed on the screen

---

## Controls

| Action | Input |
|------|------|
| Select Rock | Button click |
| Select Paper | Button click |
| Select Scissors | Button click |
| Exit game | Close window |

---

## Game Flow

1. The game starts
2. The player selects Rock, Paper, or Scissors
3. The computer makes a random choice
4. The result is evaluated
5. The outcome is displayed
6. The player can start another round

---

## Visual Feedback

- Display of player and computer choices
- Clear result message (Win / Lose / Draw)
- Simple and intuitive interface

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: RockPaperScissors/bin/Debug/
2. Run `RockPaperScissors.exe`

### Option 2: Run from Visual Studio
1. Open `RockPaperScissors.sln`
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
- Conditional logic
- Randomization
- Event handling in WinForms
- Simple game mechanics

---

## Possible Improvements

- Add score counter
- Add animations or sound effects
- Implement best-of-three mode
- Add multiplayer (local) mode
- Improve UI design
