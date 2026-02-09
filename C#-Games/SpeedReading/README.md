# Speed Reading Application

## Overview

**Speed Reading** is a simple educational desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application helps users practice speed reading by displaying words or short text segments one at a time at a controlled speed. The goal is to improve reading speed and focus.

This project demonstrates:
- Timer-based text display
- String parsing and text handling
- UI control updates in WinForms
- Basic user-controlled speed settings

---

## Application Concept

The Speed Reading application is designed to train faster reading:
- A text is split into words or chunks
- Words are displayed sequentially in the center of the screen
- The display speed can be adjusted by the user
- The user focuses on a single point instead of scanning lines of text

---

## How the Application Works

### Text Input

- The text can be:
  - Predefined in the application, or
  - Entered by the user into a text box
- The text is split into individual words or segments

---

### Speed Reading Logic

- A `Timer` controls how fast words are displayed
- On each timer tick:
  - The next word is shown
  - The display updates automatically
- When the last word is reached:
  - The reading session stops or restarts

---

### Speed Control

- The user can adjust reading speed by:
  - Changing the timer interval
  - Selecting predefined speed levels (slow, medium, fast)
- Faster speed means shorter delay between words

---

## Controls

| Action | Input |
|------|------|
| Start reading | Start button |
| Pause reading | Pause button |
| Adjust speed | Slider / buttons |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. The user enters or selects text
3. The user sets the reading speed
4. Words appear one by one on the screen
5. The session ends when the text is finished

---

## Visual Feedback

- Large, clear word display
- Minimal distractions on screen
- Immediate response to speed changes

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: SpeedReading/bin/Debug/
2. Run `SpeedReading.exe`

### Option 2: Run from Visual Studio
1. Open `SpeedReading.sln`
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
- Timer-based UI updates
- Text processing and splitting
- Focused UI design
- Educational application development in WinForms

---

## Possible Improvements

- Add words-per-minute (WPM) calculation
- Add pause/resume shortcuts
- Support importing text from files
- Highlight focus letter in each word
- Save reading statistics
