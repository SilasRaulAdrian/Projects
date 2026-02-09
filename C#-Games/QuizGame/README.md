# Quiz Game

## Overview

**Quiz Game** is a simple quiz-based desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application presents the user with a series of questions and multiple possible answers. The player selects an answer, receives feedback, and progresses through the quiz.

This project demonstrates:
- Quiz logic implementation
- Multiple-choice question handling
- Event-driven programming in WinForms
- Basic scoring and progress tracking

---

## Application Concept

The Quiz Game is designed to test knowledge in an interactive way:
- Questions are displayed one at a time
- Each question has multiple possible answers
- The user selects one answer per question
- The application evaluates the answer and updates the score

---

## How the Application Works

### Question System

- Questions are stored internally (array, list, or similar structure)
- Each question includes:
  - Question text
  - Multiple answer options
  - One correct answer

---

### Answer Validation

- When the user selects an answer:
  - The application checks if it is correct
- **Correct answer**:
  - Score increases
  - Positive feedback may be shown
- **Incorrect answer**:
  - Score does not increase
  - The correct answer may be highlighted

---

### Quiz Progression

- After answering a question:
  - The next question is loaded automatically
- The quiz continues until all questions are answered

---

## Controls

| Action | Input |
|------|------|
| Select answer | Mouse click (radio button / option) |
| Submit answer | Button click |
| Continue quiz | Automatic |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. A question is displayed
3. The user selects an answer
4. The answer is evaluated
5. The next question is shown
6. The quiz ends after the last question

---

## Visual Feedback

- Clear question and answer layout
- Visual indication of selected answers
- Score or progress display
- Simple and readable user interface

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: QuizGame/bin/Debug/
2. Run `QuizGame.exe`

### Option 2: Run from Visual Studio
1. Open `QuizGame.sln`
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
- Quiz-based application design
- Managing multiple questions and answers
- Event handling in WinForms
- Simple scoring logic

---

## Possible Improvements

- Add different quiz categories
- Add a timer for each question
- Display final results summary
- Load questions from a file or database
- Add difficulty levels
