# Image Gallery Application

## Overview

**Image Gallery** is a simple desktop application developed using  
**C# and Windows Forms (.NET Framework 4.7.2)**.  
The application allows users to browse, view, and navigate through a collection of images in an easy and intuitive way.

This project demonstrates:
- Working with images in WinForms
- File and folder handling
- Button-based navigation
- Event-driven UI logic

---

## Application Concept

The Image Gallery application provides a basic image viewer experience:
- Images are loaded from a folder or predefined resources
- The user can navigate between images
- The currently selected image is displayed on the screen

---

## How the Application Works

### Image Loading

- At startup:
  - Images are loaded from a specified directory or resource folder
  - The application stores image paths internally
- Images are displayed using a `PictureBox` control

---

### Navigation Logic

- The application keeps track of the current image index
- Navigation buttons allow:
  - Moving to the **next** image
  - Moving to the **previous** image
- Index boundaries are checked to prevent errors

---

### Display System

- Only one image is displayed at a time
- Images are resized or scaled to fit the display area
- The UI updates instantly when navigation occurs

---

## Controls

| Action | Input |
|------|------|
| View next image | Next button |
| View previous image | Previous button |
| Exit application | Close window |

---

## Application Flow

1. The application starts
2. The first image is displayed
3. The user navigates through images using buttons
4. The displayed image updates accordingly
5. The application runs until closed

---

## Visual Feedback

- Clear image display
- Smooth navigation between images
- Simple and clean user interface

---

## How to Run the Application

### Option 1: Run the Executable
1. Navigate to: ImageGallery/bin/Debug/
2. Run `ImageGallery.exe`

### Option 2: Run from Visual Studio
1. Open `ImageGallery.sln`
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
- File system navigation
- UI event handling
- Basic application flow design

---

## Possible Improvements

- Add slideshow mode
- Add zoom in / zoom out
- Support multiple image formats
- Add folder selection dialog
- Add thumbnail preview panel
