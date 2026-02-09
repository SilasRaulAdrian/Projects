# SlideShow Application

## Overview

**SlideShow** is a simple desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application displays a sequence of images one after another, either automatically or through user control, creating a basic slideshow experience.

This project demonstrates:
- Image loading and display
- Timer-based automatic transitions
- Button-based navigation
- Event-driven programming in WinForms

---

## Application Concept

The SlideShow application provides a basic image slideshow:
- Images are loaded from a folder or predefined resources
- Images are displayed one at a time
- The slideshow can move forward automatically or manually

---

## How the Application Works

### Image Loading

- At startup:
  - Images are loaded from a specified directory or resource folder
  - Image paths are stored in a list or array
- Images are displayed using a `PictureBox` control

---

### Slideshow Logic

- The application keeps track of the current image index
- A `Timer` is used to:
  - Automatically switch to the next image after a fixed interval
- When the last image is reached:
  - The slideshow loops back to the first image

---

### Manual Navigation (if implemented)

- Buttons may allow the user to:
  - Go to the **next** image
  - Go to the **previous** image
- Index limits are checked to avoid errors

---

## Controls

| Action | Input |
|------|------|
| Start / Run slideshow | Button click or automatic |
| Next image | Next button |
| Previous image | Previous button |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. The first image is displayed
3. Images change automatically or via user input
4. The slideshow loops continuously
5. The application runs until closed

---

## Visual Feedback

- Clear image display
- Smooth transitions between images
- Simple and clean user interface

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: SlideShow/bin/Debug/
2. Run `SlideShow.exe`

### Option 2: Run from Visual Studio
1. Open `SlideShow.sln`
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
- Image handling in WinForms
- Timer-based automation
- UI navigation logic
- Desktop application flow

---

## Possible Improvements

- Add transition effects (fade, slide)
- Allow user to select image folder
- Add pause / resume functionality
- Add full-screen mode
- Add configurable delay time
