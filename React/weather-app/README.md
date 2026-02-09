# Weather App

## Technical Overview

This project is a **Weather Dashboard** web application built with **Next.js** and **React**, designed to demonstrate frontend skills such as API integration, component-driven architecture, asynchronous data handling, and state management. The application aggregates multiple weather-related data sources and presents them in a structured, user-friendly interface.

## Functional Scope

* City-based weather search
* Current weather conditions (temperature, feels-like)
* Daily and multi-day weather forecasts
* Atmospheric data (humidity, pressure, visibility)
* UV index visualization
* Sunrise and sunset times
* Air pollution and air quality data
* Interactive map visualization using Mapbox
* Theme switching (e.g. light / dark mode)

## Architecture and Design

The application follows a modular, scalable architecture based on reusable React components and Next.js conventions.

### Component Breakdown

* `Navbar`

  * Global navigation and theme selection

* `SearchDialog`

  * Handles user input and city search logic

* `Temperature`, `FeelsLike`

  * Displays current temperature data

* `DailyForecast`, `FiveDayForecast`

  * Responsible for rendering forecast data

* `Humidity`, `Pressure`, `Visibility`

  * Atmospheric condition components

* `UvIndex`, `UvProgress`

  * UV radiation data and visualization

* `Sunset`

  * Sunrise and sunset information

* `Mapbox`

  * Displays city location on an interactive map

* `AirPollution`

  * Air quality and pollution metrics

## State Management Strategy

* Local component state is managed using React hooks (`useState`, `useEffect`)
* API data is fetched asynchronously and stored in state
* Loading and error states are handled to ensure stable UI rendering
* State updates follow immutable patterns for predictability

## Data Flow

* Unidirectional data flow from parent containers to presentational components
* API responses are normalized before being passed down as props
* Child components remain focused on rendering, not data fetching

## API Integration

* External weather APIs (e.g. OpenWeather) are used to fetch:

  * Current weather data
  * Forecast data
  * Air pollution data
* API calls are triggered based on user search input
* Environment variables are used to secure API keys

## Map Integration

* **Mapbox** is used to visualize the geographic location of the selected city
* Coordinates from the weather API are reused to avoid redundant requests

## Error Handling and Edge Cases

* Handles invalid or unknown city names
* Displays fallback UI during loading or API errors
* Prevents rendering crashes on incomplete API responses

## Technologies Used

* **Next.js** – application structure, routing, and optimization
* **React** – component-based UI development
* **TypeScript** – type safety and improved maintainability
* **Mapbox** – interactive maps
* **Weather APIs** – external data sources
* **CSS / UI libraries** – styling and layout

## Local Development Setup

1. Install dependencies:

   ```bash
   npm install
   ```
2. Run the development server:

   ```bash
   npm run dev
   ```
3. Open the application at:

   ```
   http://localhost:3000
   ```

## Possible Improvements

* Server-side rendering (SSR) or static generation for SEO
* Caching API responses
* Custom hooks for data fetching logic
* Unit and integration testing
* Improved accessibility (ARIA, keyboard navigation)

This project represents a technically solid example of a modern frontend application using Next.js and React.
