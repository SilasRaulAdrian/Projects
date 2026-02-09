# Media Player Application

## Overview

**Media Player** is a simple desktop media player application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application allows users to load and play media files, providing basic playback controls in a clean and easy-to-use interface.

This project demonstrates:
- Working with media playback in WinForms
- File selection using dialogs
- Button-based control logic
- Event-driven application design

---

## Application Concept

The Media Player application provides core media playback functionality:
- Load audio or video files from the local system
- Play, pause, and stop media playback
- Control playback flow through UI buttons

---

## How the Application Works

### Media Loading

- The user selects a media file using an **Open File Dialog**
- Supported media formats depend on the system’s media codecs
- Once loaded, the media file is ready for playback

---

### Playback Controls

The application provides basic media controls:

- **Play**
  - Starts or resumes playback
- **Pause**
  - Temporarily pauses playback
- **Stop**
  - Stops playback and resets the position

Playback is handled through a media component integrated into the WinForms application.

---

### Playback State Management

- The application keeps track of the current playback state
- Buttons trigger different playback actions
- The UI updates based on the selected action

---

## Controls

| Action | Input |
|------|------|
| Load media file | Open button |
| Play media | Play button |
| Pause media | Pause button |
| Stop media | Stop button |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. The user loads a media file
3. Playback controls become active
4. The user controls playback using buttons
5. The application runs until closed

---

## Visual Feedback

- Media is displayed (for video files)
- Playback responds instantly to user input
- Simple and intuitive control layout

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: MediaPlayer/bin/Debug/
2. Run `MediaPlayer.exe`

### Option 2: Run from Visual Studio
1. Open `MediaPlayer.sln`
2. Build the solution
3. Press **F5** to start the application

---

## Requirements

- Windows Operating System
- .NET Framework 4.7.2 or newer
- Media codecs installed on the system
- Visual Studio (optional, for development)

---

## Educational Purpose

This project is useful for learning:
- Media handling in WinForms
- File dialog usage
- Playback control logic
- Event-driven UI programming

---

## Possible Improvements

- Add volume control
- Add playback progress bar
- Support playlists
- Remember last opened file
- Improve UI design
