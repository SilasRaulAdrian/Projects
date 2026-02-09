# Number Guessing Game

## Overview

**Number Guessing Game** is a simple educational game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The goal of the game is for the player to guess a randomly generated number within a certain range. The application provides feedback after each guess to guide the player toward the correct answer.

This project demonstrates:
- Random number generation
- User input validation
- Conditional logic
- Event-driven programming in WinForms

---

## Game Concept

The game follows a classic number guessing concept:
- The application generates a random number
- The player attempts to guess the number
- Feedback is provided after each attempt
- The game ends when the correct number is guessed

---

## How the Game Works

### Number Generation

- When the game starts:
  - A random number is generated within a predefined range (for example, 1–100)
  - The number remains hidden from the player

---

### Guessing Logic

- The player enters a number into an input field
- The application compares the input with the hidden number
- Feedback is provided based on the comparison

---

### Feedback System

- **Too high**:
  - The application informs the player that the guess is too large
- **Too low**:
  - The application informs the player that the guess is too small
- **Correct guess**:
  - A success message is displayed
  - The game ends or resets

---

## Controls

| Action | Input |
|------|------|
| Enter a guess | Keyboard input |
| Submit guess | Button click |
| Exit game | Close window |

---

## Game Flow

1. The game starts
2. A random number is generated
3. The player enters a guess
4. Feedback is shown
5. Steps 3–4 repeat until the correct number is guessed

---

## Visual Feedback

- Clear input field for guesses
- Feedback messages displayed on screen
- Simple and clean user interface

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: NumberGuessing/bin/Debug/
2. Run `NumberGuessing.exe`

### Option 2: Run from Visual Studio
1. Open `NumberGuessing.sln`
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
- Input validation
- Basic game logic in WinForms

---

## Possible Improvements

- Add limited number of attempts
- Add difficulty levels (different ranges)
- Track number of guesses
- Add restart button
- Add score system
