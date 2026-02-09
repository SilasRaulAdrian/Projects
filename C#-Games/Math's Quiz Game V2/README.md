# Math’s Quiz Game V2

## Overview

**Math’s Quiz Game V2** is an improved educational quiz application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
This version builds upon the first release by offering enhanced gameplay flow, better feedback, and a more structured quiz experience for practicing arithmetic skills.

This project demonstrates:
- Event-driven programming in WinForms
- Randomized math question generation
- User input validation
- Score and progress tracking

---

## Purpose of the Application

The main goals of this application are to:
- Help users practice and improve basic math skills
- Provide an interactive and engaging quiz experience
- Demonstrate a more advanced quiz logic compared to Version 1

---

## How the Application Works

### Quiz Logic

1. A math question is generated automatically
2. Questions may include operations such as:
   - Addition
   - Subtraction
   - Multiplication
   - Division (if enabled)
3. The user inputs an answer
4. The system validates the answer and provides feedback
5. The quiz continues with the next question

---

### Answer Validation and Scoring

- **Correct answer**:
  - The score increases
  - Positive feedback is shown
- **Incorrect answer**:
  - The score does not increase
  - The correct answer may be displayed

The application keeps track of the total score throughout the session.

---

## User Interaction

### Controls

| Action | Input |
|------|------|
| Enter numeric answer | Keyboard input |
| Submit answer | Button click |
| Continue to next question | Automatic |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. A math question is displayed
3. The user enters an answer
4. The system checks correctness
5. Feedback is shown
6. A new question is generated

This cycle repeats until the user closes the application.

---

## Visual Feedback

- Clearly displayed math questions
- Input field for user answers
- Feedback messages for correct or incorrect answers
- Score display that updates dynamically

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: MathsQuizGameV2/bin/Debug/
2. Run `MathsQuizGameV2.exe`

### Option 2: Run from Visual Studio
1. Open `MathsQuizGameV2.sln`
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
- Arithmetic logic implementation
- Quiz-based application flow
- Input validation techniques
- Windows Forms UI development

---

## Improvements Over Version 1

- Better score handling
- Improved user feedback
- More structured quiz flow
- Cleaner and more organized logic

---

## Possible Improvements

- Add difficulty levels
- Add a countdown timer
- Track high scores
- Add result summary at the end
- Save progress to a file
