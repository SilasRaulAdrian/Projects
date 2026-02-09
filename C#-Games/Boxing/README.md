# Boxing Game

## Overview

**Boxing Game** is a simple 2D fighting game developed using **C# and Windows Forms (.NET Framework 4.7.2)**.  
The game simulates a boxing match where the player controls a boxer and competes against an opponent. The objective is to attack the opponent, avoid incoming hits, and win the match by reducing the opponent’s health to zero.

This project focuses on:
- Event-driven programming in WinForms
- Player input handling
- Health and damage mechanics
- Basic game logic without a game engine

---

## Game Concept

The game represents a simplified boxing match:
- The player and the opponent are displayed on the screen
- Each character has a health bar
- Attacks reduce the opponent’s health
- The game ends when one boxer’s health reaches zero

---

## How the Game Works

### Characters

- **Player Boxer**
  - Controlled by the user
  - Can attack the opponent
- **Enemy Boxer**
  - Controlled by the game logic
  - Attacks automatically or in response to player actions

Both characters use images or animations to represent punches and idle states.

---

### Health System

- Each boxer starts with a fixed amount of health
- When a punch lands:
  - Health is reduced
  - The health bar updates visually
- When health reaches zero:
  - The match ends
  - A win or loss message is displayed

---

### Game Loop

- The game logic runs using timers
- Timers handle:
  - Character movement or animations
  - Enemy attacks
  - Collision checks between punches and characters

---

## Controls

| Action | Input |
|------|------|
| Attack / Punch | Button click or key press |
| Avoid attacks | Automatic / positioning |
| End game | When health reaches zero |

---

## Game Over Conditions

- **Player Wins**:
  - Enemy health reaches zero
  - Victory message is displayed
- **Player Loses**:
  - Player health reaches zero
  - Defeat message is displayed

After the game ends, no further actions are processed.

---

## Visual Feedback

- Punch animations indicate attacks
- Health bars clearly show remaining health
- Messages inform the player about win or loss

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: Boxing/bin/Debug/
2. Run `Boxing.exe`

### Option 2: Run from Visual Studio
1. Open `Boxing.sln`
2. Build the solution
3. Press **F5** to start the game

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project demonstrates:
- Basic fighting game mechanics
- Health and damage systems
- Timers used as a game loop
- Handling user input in WinForms

---

## Possible Improvements

- Add movement controls
- Add multiple opponents
- Implement sound effects
- Add rounds and scoring
- Improve animations
