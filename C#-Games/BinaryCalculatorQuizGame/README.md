# Binary Calculator Quiz Game

## Overview

**Binary Calculator Quiz Game** is an educational desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application is designed to help users practice and understand **binary number operations** through an interactive quiz-based system.

The game challenges the player to solve binary calculations and provides immediate feedback on each answer.

---

## Purpose of the Application

The main goal of this project is to:
- Improve understanding of binary numbers
- Practice binary arithmetic in an interactive way
- Demonstrate event-driven programming in Windows Forms

This project is suitable for students learning:
- Binary number systems
- Basic computer science concepts
- C# WinForms development

---

## How the Application Works

### Quiz Logic

1. The game generates binary numbers
2. A mathematical operation is applied (such as addition)
3. The user must calculate and enter the correct binary result
4. The answer is validated when the user submits it

---

### Answer Validation

- **Correct answer**:
  - The score increases
  - Positive feedback is displayed
- **Incorrect answer**:
  - The correct answer may be shown
  - The score does not increase

The application keeps track of user performance throughout the session.

---

## User Interaction

### Controls

| Action | Input |
|------|------|
| Enter binary answer | Keyboard input |
| Submit answer | Button click |
| Continue quiz | Automatic |

---

## Game Flow

1. The application starts with a quiz question
2. The user enters a binary result
3. The system checks the answer
4. Feedback is displayed
5. A new question is generated

This loop continues until the application is closed.
---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: BinaryCalculatorQuizGame/bin/Debug/
2. Run `BinaryCalculatorQuizGame.exe`

### Option 2: Run from Visual Studio
1. Open `BinaryCalculatorQuizGame.sln`
2. Build the solution
3. Press **F5** to start the application

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Value

This project demonstrates:
- Binary number manipulation
- Input validation
- Event handling in WinForms
- Simple quiz game logic

---

## Possible Improvements

- Add subtraction, multiplication, or division
- Add difficulty levels
- Implement a timer
- Save high scores
- Add explanations for correct answers
