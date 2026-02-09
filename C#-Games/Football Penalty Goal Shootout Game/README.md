# Football Penalty Goal Shootout Game

## Overview

**Football Penalty Goal Shootout Game** is a simple sports arcade game developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The game simulates a football penalty shootout where the player attempts to score goals by shooting the ball past the goalkeeper.

This project focuses on:
- Mouse or keyboard input handling
- Object movement and animation
- Collision detection
- Simple scoring logic

---

## Game Concept

The game is based on a penalty kick scenario:
- The player controls the direction of the football shot
- A goalkeeper attempts to block the shot
- The objective is to score as many goals as possible

---

## How the Game Works

### Game Objects

- **Football**
  - Shot by the player toward the goal
  - Moves in the selected direction

- **Goalkeeper**
  - Moves left and right in front of the goal
  - Attempts to block incoming shots

- **Goal**
  - The target area where the ball must enter to score

---

### Game Loop

The main game logic runs using a `Timer`:
1. The goalkeeper moves continuously
2. The football moves when a shot is taken
3. Collision detection checks:
   - Ball vs goalkeeper
   - Ball vs goal
4. The score is updated based on the result

---

### Scoring Logic

- **Goal Scored**:
  - Ball enters the goal without touching the goalkeeper
  - Score increases

- **Missed Shot**:
  - Ball hits the goalkeeper or misses the goal
  - No score is awarded

After each attempt, the ball resets for the next shot.

---

## Controls

| Action | Input |
|------|------|
| Aim / Shoot | Mouse click or key press |
| Start next shot | Automatic |
| Exit game | Close window |

---

## Game Flow

1. The game starts automatically
2. The goalkeeper begins moving
3. The player takes a shot
4. The game evaluates the result
5. The next penalty attempt begins

---

## Visual Feedback

- Moving goalkeeper animation
- Ball movement animation
- Score displayed on screen

---

## How to Run the Game

### Option 1: Run the Executable
1. Navigate to: FootballPenaltyShootout/bin/Debug/
2. Run `FootballPenaltyShootout.exe`

### Option 2: Run from Visual Studio
1. Open `FootballPenaltyShootout.sln`
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
- Basic sports game mechanics
- Timers and animation
- Collision detection
- Input handling in WinForms

---

## Possible Improvements

- Add multiple difficulty levels
- Add sound effects
- Add penalty shootout rounds
- Improve goalkeeper AI
- Add score history
