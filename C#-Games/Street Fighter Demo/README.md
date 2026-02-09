# Street Fighter Demo

## Overview

**Street Fighter Demo** is a simple 2D fighting game demo developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application demonstrates basic fighting game mechanics such as player movement, attacks, health management, and win/lose conditions inspired by classic arcade fighting games.

This project is intended as a demo or learning project, not a full commercial game.

---

## Game Concept

The demo simulates a one-on-one fighting scenario:
- Two fighters are displayed on the screen
- One fighter is controlled by the player
- The opponent may be controlled by basic game logic
- The goal is to reduce the opponent’s health to zero

---

## How the Game Works

### Characters

- **Player Fighter**
  - Controlled by the user
  - Can move and perform attacks

- **Opponent Fighter**
  - Controlled by simple AI logic or predefined behavior
  - Performs attacks automatically or in response to player actions

Each character has a health bar that decreases when hit.

---

### Combat Mechanics

- Attacks are triggered by keyboard input
- When an attack collides with the opponent:
  - Damage is applied
  - The opponent’s health bar decreases
- Visual feedback indicates successful hits

---

### Game Loop

The main game logic runs using one or more `Timer` components:
1. Character positions are updated
2. Player input is processed
3. Attacks and collisions are checked
4. Health values are updated
5. Game state is evaluated

---

### Win and Lose Conditions

- **Player Wins**:
  - Opponent’s health reaches zero
- **Player Loses**:
  - Player’s health reaches zero

When the match ends, a message is displayed and gameplay stops.

---

## Controls

| Action | Input |
|------|------|
| Move left | Left Arrow key |
| Move right | Right Arrow key |
| Attack | Action key (e.g. Spacebar or specific key) |
| Exit game | Close window |

---

## Visual Feedback

- Character sprites represent fighters
- Health bars display remaining health
- Attack animations indicate combat actions
- Clear win or lose message at the end of the match

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: StreetFighterDemo/bin/Debug/
2. Run `StreetFighterDemo.exe`

### Option 2: Run from Visual Studio
1. Open `StreetFighterDemo.sln`
2. Build the solution
3. Press **F5** to start the demo

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Visual Studio (optional, for development)

---

## Educational Purpose

This project is useful for learning:
- Fighting game fundamentals
- Health and damage systems
- Collision detection
- Timer-based animation in WinForms

---

## Possible Improvements

- Add multiple attack types
- Add blocking or jumping
- Improve enemy AI
- Add sound effects
- Add character selection screen
