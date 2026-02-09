# Meme Maker Application

## Overview

**Meme Maker** is a simple desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application allows users to create memes by selecting an image and adding custom text on top of it. The final result can be previewed directly within the application.

This project demonstrates:
- Image loading and rendering
- Text overlay on images
- User input handling
- Basic graphic manipulation in WinForms

---

## Application Concept

The Meme Maker application provides a basic meme creation experience:
- Load an image from the local system
- Add custom text (top text, bottom text, or both)
- Preview the meme directly on the screen

---

## How the Application Works

### Image Loading

- The user selects an image using an **Open File Dialog**
- The selected image is displayed inside a `PictureBox`
- The image is scaled to fit the display area

---

### Text Overlay

- The user enters text into input fields
- Text is drawn over the image using graphics methods
- Text positioning is typically:
  - Top of the image
  - Bottom of the image
- Font style and size are predefined or adjustable

---

### Preview System

- The meme preview updates when text is added or changed
- The user can see the final result instantly
- No external image editor is required

---

## Controls

| Action | Input |
|------|------|
| Load image | Open Image button |
| Enter meme text | Keyboard input |
| Preview meme | Automatic |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. The user loads an image
3. The user enters meme text
4. The image updates with the text overlay
5. The application runs until closed

---

## Visual Feedback

- Clear image preview
- Visible and readable text overlay
- Simple and user-friendly interface

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: MemeMaker/bin/Debug/
2. Run `MemeMaker.exe`

### Option 2: Run from Visual Studio
1. Open `MemeMaker.sln`
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
- Image processing basics
- Drawing text using Graphics
- Handling user input
- WinForms UI design

---

## Possible Improvements

- Allow custom font selection
- Add text color options
- Enable saving the meme as an image file
- Add drag-and-drop text positioning
- Support multiple text layers
