# Math’s Quiz Game V1

## Overview

**Math’s Quiz Game V1** is a simple educational quiz application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application challenges users with basic math questions and provides instant feedback on their answers, helping improve arithmetic skills in an interactive way.

This project demonstrates:
- Event-driven programming in WinForms
- Basic arithmetic logic
- User input validation
- Simple score tracking

---

## Purpose of the Application

The main goal of the application is to:
- Help users practice basic math operations
- Provide instant feedback for learning
- Demonstrate a quiz-based application structure in C#

---

## How the Application Works

### Quiz Logic

1. The application generates a math question
2. The question involves basic arithmetic operations such as:
   - Addition
   - Subtraction
   - Multiplication
   - Division (if included)
3. The user enters an answer
4. The answer is checked for correctness

---

### Answer Validation

- **Correct answer**:
  - The user is notified
  - The score increases
- **Incorrect answer**:
  - The user is informed
  - The correct answer may be displayed

The game then moves on to the next question.

---

## User Interaction

### Controls

| Action | Input |
|------|------|
| Enter answer | Keyboard input |
| Submit answer | Button click |
| Continue quiz | Automatic |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. A math question is displayed
3. The user enters an answer
4. The system validates the input
5. Feedback is shown
6. A new question is generated

This loop continues until the application is closed.

---

## Visual Feedback

- Clear question display
- Input field for answers
- Feedback messages for correct or incorrect responses
- Score display (if implemented)

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: MathsQuizGameV1/bin/Debug/
2. Run `MathsQuizGameV1.exe`

### Option 2: Run from Visual Studio
1. Open `MathsQuizGameV1.sln`
2. Build the solution
3. Press **F5** to start the application

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project is useful for learning:
- Basic arithmetic operations
- Quiz-style application logic
- Input handling and validation
- WinForms UI development

---

## Possible Improvements

- Add difficulty levels
- Add a timer for each question
- Track high scores
- Add more question types
- Save results to a file
