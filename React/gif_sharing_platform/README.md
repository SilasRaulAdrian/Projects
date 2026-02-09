# GIF Sharing Platform

A frontend web application that allows users to search, view, and share GIFs fetched from an external API.

---

## Overview

GIF Sharing Platform is a frontend application built using **React**.  
The application allows users to discover and preview GIFs by searching keywords, with all data fetched from an external GIF API.

The project focuses on API integration, dynamic rendering, and responsive user interface design.

---

## How It Works

1. The user enters a search keyword.
2. The application sends a request to an external GIF API.
3. GIF data is fetched asynchronously.
4. The results are displayed dynamically in a responsive grid layout.
5. Loading, error, and empty states are handled gracefully.

---

## Features

- Search GIFs by keyword
- Fetch GIFs from an external API
- Display GIFs in a responsive grid
- Preview individual GIFs
- Loading and error handling
- Fully responsive design

---

## Technologies Used

- React
- JavaScript (ES6)
- External GIF API
- HTML5
- CSS3

---

## Installation

1. Download or clone the repository.
2. Navigate to the project folder:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm start
   ```

The application will run on `http://localhost:3000`.

---

## Usage

1. Open the application in a web browser.
2. Enter a keyword in the search bar.
3. Browse the displayed GIF results.
4. Click on a GIF to preview it.

---

## Possible Improvements

- Add pagination or infinite scrolling
- Implement debounced search
- Allow users to save favorite GIFs
- Improve UI animations
- Add backend persistence
