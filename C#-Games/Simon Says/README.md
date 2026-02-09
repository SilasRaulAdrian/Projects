# Simon Says Game

## Overview

**Simon Says Game** is a simple memory-based game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game challenges the player to remember and repeat an increasing sequence of colors or buttons. With each successful round, the sequence becomes longer and more difficult.

This project demonstrates:
- Memory game mechanics
- Timer-based animations
- Event-driven programming in WinForms
- Game state and sequence management

---

## Game Concept

The game is inspired by the classic **Simon Says** electronic game:
- The game generates a sequence of colors
- The player must repeat the sequence in the correct order
- Each round adds a new step to the sequence
- A mistake ends the game

---

## How the Game Works

### Game Elements

- **Buttons / Panels**
  - Each button represents a different color
  - Buttons light up to show the sequence

- **Sequence List**
  - Stores the generated order of colors
  - Grows by one element each round

---

### Game Loop

1. The game starts with an empty sequence
2. A random color is added to the sequence
3. The sequence is displayed using timed button highlights
4. The player repeats the sequence by clicking buttons
5. Input is checked step by step
6. If correct, the next round begins
7. If incorrect, the game ends

---

### Input Validation

- Player input is compared to the stored sequence
- If a button is pressed out of order:
  - The game stops
  - A **Game Over** message is displayed

---

## Controls

| Action | Input |
|------|------|
| Select color | Mouse click |
| Start game | Button click |
| Exit game | Close window |

---

## Game Over Condition

- The player presses an incorrect button
- The sequence timer stops
- A game over message is shown

---

## Visual Feedback

- Buttons flash to display the sequence
- Clear indication of player input
- Immediate feedback on mistakes

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: SimonSays/bin/Debug/
2. Run `SimonSays.exe`

### Option 2: Run from Visual Studio
1. Open `SimonSays.sln`
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
- Memory-based game logic
- Timers and animation sequencing
- Event handling
- Managing game state in WinForms

---

## Possible Improvements

- Add sound cues for each color
- Track highest score (longest sequence)
- Add difficulty levels
- Improve visual animations
- Add restart button
