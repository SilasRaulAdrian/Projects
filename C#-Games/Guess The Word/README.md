# Guess The Word Game

## Overview

**Guess The Word Game** is a simple word-guessing game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The player must guess a hidden word by entering letters or full words. The game provides feedback for each guess and continues until the word is guessed correctly or the game ends.

This project demonstrates:
- String manipulation
- User input validation
- Basic game state management
- Event-driven programming in WinForms

---

## Game Concept

The game is inspired by classic word guessing games:
- A word is selected from a predefined list
- The word is hidden from the player
- The player guesses letters or the entire word
- Correct guesses reveal parts of the word

---

## How the Game Works

### Word Selection

- At the start of the game:
  - A random word is chosen from a predefined list
  - The word is masked using placeholders (e.g., underscores)

---

### Guessing Logic

- The player enters:
  - A single letter, or
  - A full word guess
- The game checks if the guess is correct

---

### Feedback System

- **Correct letter**:
  - The letter is revealed in the word
- **Incorrect letter**:
  - The game continues without revealing new letters
- **Correct word**:
  - The player wins the game
- **Incorrect word**:
  - The game continues or ends based on rules

---

## Controls

| Action | Input |
|------|------|
| Enter letter or word | Keyboard input |
| Submit guess | Button click |
| Exit game | Close window |

---

## Game Flow

1. The game starts automatically
2. A hidden word is displayed as placeholders
3. The player enters guesses
4. The game updates the displayed word
5. The game ends when the word is guessed

---

## Visual Feedback

- Updated word display after each guess
- Clear input and result feedback
- Simple and readable interface

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: GuessTheWord/bin/Debug/
2. Run `GuessTheWord.exe`

### Option 2: Run from Visual Studio
1. Open `GuessTheWord.sln`
2. Build the solution
3. Press **F5** to start the game

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project helps in learning:
- String handling and comparison
- User input validation
- Game logic design
- Windows Forms event handling

---

## Possible Improvements

- Add limited attempts
- Add categories or difficulty levels
- Add score tracking
- Add hints system
- Add word list from file
