# Picture Matching Game

## Overview

**Picture Matching Game** is a simple memory-based game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The objective of the game is to match pairs of identical images by flipping cards. The player must remember the position of images and match all pairs to complete the game.

This project demonstrates:
- Memory game logic
- Event-driven programming in WinForms
- Image handling with PictureBox controls
- Game state management

---

## Game Concept

The game is based on a classic memory matching concept:
- A grid of hidden images is displayed
- Each image appears exactly twice
- The player reveals two images at a time
- If the images match, they remain visible
- If they do not match, they are hidden again

---

## How the Game Works

### Game Board

- The game board is created using multiple `PictureBox` controls
- Images are randomly assigned to each position
- All images start face-down

---

### Matching Logic

1. The player clicks on the first image
2. The image is revealed
3. The player clicks on a second image
4. The game compares both images:
   - If they match → both remain visible
   - If they do not match → both are hidden again after a short delay

---

### Game State Management

- The game keeps track of:
  - First selected image
  - Second selected image
  - Number of matched pairs
- User input is temporarily disabled while unmatched images are being hidden

---

## Controls

| Action | Input |
|------|------|
| Reveal image | Left mouse click |
| Continue game | Automatic |
| Exit game | Close window |

---

## Win Condition

- All image pairs are successfully matched
- A completion or victory message is displayed

---

## Visual Feedback

- Images flip when clicked
- Matched images stay visible
- Smooth and intuitive interaction

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: PictureMatching/bin/Debug/
2. Run `PictureMatching.exe`

### Option 2: Run from Visual Studio
1. Open `PictureMatching.sln`
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
- Event handling with multiple controls
- Timers and delays
- Image management in WinForms

---

## Possible Improvements

- Add timer or move counter
- Add difficulty levels (grid size)
- Add sound effects
- Add restart button
- Track best completion times
