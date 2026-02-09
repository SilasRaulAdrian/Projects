# Play Multiple Sound File Application

## Overview

**Play Multiple Sound File** is a simple desktop audio application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application allows users to load and play multiple sound files, either individually or one after another, using a simple and intuitive interface.

This project demonstrates:
- Audio playback in WinForms
- Managing multiple sound files
- Button-based control logic
- Event-driven programming

---

## Application Concept

The application is designed to handle multiple audio files:
- Users can load more than one sound file
- Each sound can be played independently
- The application can manage and switch between different audio files

---

## How the Application Works

### Sound File Loading

- The user selects one or more sound files using an **Open File Dialog**
- Selected files are stored in a list or collection
- Supported formats depend on the system’s audio capabilities (e.g., WAV, MP3)

---

### Playback Logic

- Each sound file can be:
  - Played
  - Stopped
- Playback is handled using audio components available in WinForms

---

### Multiple Sound Management

- The application keeps track of all loaded sound files
- The user can choose which sound to play
- Only the selected sound is played at a time (unless otherwise implemented)

---

## Controls

| Action | Input |
|------|------|
| Load sound files | Open button |
| Play sound | Play button |
| Stop sound | Stop button |
| Switch sound | Selection control (list or buttons) |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. The user loads multiple sound files
3. The user selects a sound
4. Playback starts or stops based on user input
5. The application runs until closed

---

## Visual Feedback

- List of loaded sound files
- Clear playback controls
- Immediate response to user actions

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: PlayMultipleSoundFile/bin/Debug/
2. Run `PlayMultipleSoundFile.exe`

### Option 2: Run from Visual Studio
1. Open `PlayMultipleSoundFile.sln`
2. Build the solution
3. Press **F5** to start the application

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Audio codecs installed on the system
- Visual Studio (optional, for development)

---

## Educational Purpose

This project is useful for learning:
- Audio playback handling
- Managing multiple media resources
- UI interaction with media controls
- Event-driven application flow

---

## Possible Improvements

- Add volume control
- Support playlists or autoplay
- Add pause/resume functionality
- Display audio duration
- Improve UI design
