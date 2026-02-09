# Rock Paper Scissors Game

## Overview

**Rock Paper Scissors Game** is a simple desktop game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application lets the player play the classic Rock–Paper–Scissors game against the computer. Each round results in a win, loss, or draw based on standard rules.

This project demonstrates:
- Random choice generation
- Conditional logic
- Event-driven programming in WinForms
- Simple game flow management

---

## Game Concept

The game follows the traditional Rock–Paper–Scissors rules:

- Rock beats Scissors  
- Scissors beats Paper  
- Paper beats Rock  

The player selects one option, the computer selects another randomly, and the outcome is displayed.

---

## How the Game Works

### Player Selection

- The player chooses one of the following options:
  - Rock
  - Paper
  - Scissors
- The selection is made using buttons or clickable UI elements

---

### Computer Selection

- The computer randomly selects one option each round
- Randomization ensures unpredictable outcomes

---

### Result Evaluation

- The game compares the player’s choice with the computer’s choice
- The result is determined as:
  - **Win**
  - **Lose**
  - **Draw**
- The result is displayed immediately on the screen

---

## Controls

| Action | Input |
|------|------|
| Choose Rock | Button click |
| Choose Paper | Button click |
| Choose Scissors | Button click |
| Exit game | Close window |

---

## Game Flow

1. The game starts
2. The player selects Rock, Paper, or Scissors
3. The computer generates a random choice
4. The game evaluates the result
5. The outcome is displayed
6. The player can play another round

---

## Visual Feedback

- Display of player choice
- Display of computer choice
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
- Conditional statements
- Random number generation
- Event handling in WinForms
- Simple interactive game design

---

## Possible Improvements

- Add score tracking
- Implement best-of-three or best-of-five mode
- Add sound effects
- Improve UI design
- Add animations
