
# Lofi Study App

## Overview

Lofi Study App is a relaxing web application designed to help users focus while studying, working, or relaxing.  
The application allows users to play **lofi music**, **ambient sound effects**, and **background videos** to create a customizable study atmosphere.

The project is built using **React + TypeScript** and follows a modular component-based architecture.

---

# Features

- Play different **lofi music tracks**
- Add **ambient sound effects** (rain, forest, fire, etc.)
- Watch relaxing **background videos**
- Control **volume**
- Switch between different **music categories**
- Combine music and ambient sounds for a personalized study environment

---

# How the Application Works

The application is divided into several main components that work together.

## 1. Video Background

The **VideoPlayer component** displays relaxing background videos such as:

- Rain scenes
- Cozy study rooms
- Fireplace environments
- Nature landscapes

Users can switch between different videos to change the atmosphere.

Video files are stored inside:

```
src/assets/videos
```

---

## 2. Music Player

The **MusicPanel** manages the main background music.

Music tracks are grouped into categories such as:

- Lofi beats
- Ambient music
- Piano music
- Nature soundtracks

Music files are located in:

```
src/assets/music
```

The player allows users to:

- Play music
- Pause music
- Skip to the next track
- Change music category

---

## 3. Ambient Sound Effects

Users can add **ambient sound effects** on top of the music to improve focus.

Examples:

- Rain
- Forest
- Wind
- Fire
- Water stream
- Traffic noise

Each sound effect can be activated independently and has its own **volume control**.

These are handled by:

- `SfxControl`
- `SfxControlPanel`

Sound files are located in:

```
src/assets/sfx
```

---

## 4. Player Controls

The **PlayerControls component** handles basic playback functionality:

- Play / Pause
- Next track
- Volume control

This component interacts with the music state stored in the main application.

---

## 5. Data Configuration

Music tracks, sound effects, and videos are organized using configuration files inside:

```
src/data
```

Examples:

- `musicCategories.ts`
- `sfxData.ts`
- `videoCategoryData.ts`

These files define:

- Available tracks
- File paths
- Categories
- Display information

This makes the app easy to extend with new content.

---

# How to Run the Project

### 1. Install dependencies

```
npm install
```

### 2. Start the development server

```
npm run dev
```

### 3. Open the application

```
http://localhost:5173
```

---

# How to Use the Application

1. Start the application in the browser.
2. Choose a **background video** for the atmosphere.
3. Select a **music category** and start playing a track.
4. Add **ambient sound effects** such as rain or forest sounds.
5. Adjust the **volume** for music and sound effects.
6. Combine different sounds to create your ideal study environment.

---

# Technologies Used

- React
- TypeScript
- Vite
- HTML / CSS
- Modular component architecture

---

# Possible Improvements

- Add user playlists
- Save user preferences
- Add timer (Pomodoro mode)
- Add more sound effects and music tracks
- Mobile UI optimization
- Dark/light theme toggle

---

# Purpose of the Project

This project was created to practice:

- React component architecture
- TypeScript usage in frontend applications
- Audio and video handling in the browser
- State management in React
- Building interactive user interfaces
