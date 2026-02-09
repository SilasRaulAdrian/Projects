# Weather App

A simple web-based Weather Application that allows users to check real-time weather information for any city using a public weather API.

---

## Overview

This project is a frontend weather application built using **HTML, CSS, and JavaScript**.  
The application fetches real-time weather data from an external API and displays useful weather information to the user.

The project demonstrates API usage, asynchronous JavaScript (`fetch`), and dynamic DOM manipulation.

---

## How It Works

1. The user enters a city name in the input field.
2. When the search button is clicked:
   - The application sends a request to the Weather API using `fetch`.
   - The API responds with weather data in JSON format.
3. The application extracts the relevant information from the response.
4. The UI updates dynamically and displays:
   - City name
   - Temperature
   - Weather description
   - Humidity
   - Wind speed
5. If the city name is invalid or the request fails, an error message is shown.

---

## Features

- Search weather by city name
- Real-time weather data
- Simple and clean user interface
- Error handling for invalid cities
- Responsive layout

---

## Technologies Used

- HTML5
- CSS3
- JavaScript (ES6)
- Weather API (e.g. OpenWeatherMap)

---

## Installation

1. Download or clone the repository.
2. Open the project folder.
3. If the project requires an API key:
   - Open the JavaScript file.
   - Replace the placeholder API key with your own key.
  
---

## Usage

1. Open the `index.html` file in a web browser.
2. Enter the name of a city in the input field.
3. Click the search button.
4. The application will display the current weather information for the selected city.

---

## Possible Improvements

- Add weather icons based on current conditions
- Implement a multi-day weather forecast
- Add geolocation support to detect the user’s location automatically
- Improve UI animations and transitions
- Allow temperature unit switching (Celsius / Fahrenheit)
