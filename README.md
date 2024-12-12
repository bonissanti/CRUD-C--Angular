# Super Hero CRUD API

## Overview

This project is a CRUD (Create, Read, Update, Delete) API for managing super heroes. The API allows clients to create, retrieve, update, and delete super hero records, including their names, hero names, birth dates, heights, weights, and super powers.

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
  - [API Endpoints](#api-endpoints)
    - [Get All Super Heroes](#get-all-super-heroes)
    - [Get Super Hero by ID](#get-super-hero-by-id)
    - [Create Super Hero](#create-super-hero)
    - [Update Super Hero](#update-super-hero)
    - [Delete Super Hero](#delete-super-hero)
- [Models](#models)
- [Error Handling](#error-handling)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (this project is compatible with .NET 7.0 and above)
- [Angular CLI](https://angular.io/cli) (for the frontend)

### Installation

1. Clone the repository:
   ```bash
   https://github.com/bonissanti/CRUD-CSharp-Angular.git
   cd SuperHeroCrud

2. Build and run the backend:
   ```bash
   dotnet build
   dotnet run

3. Start frontend:
   ```bash
   cd ../frontend/
   ng serve
---
### API Endpoints

**Get all super heroes.**

- URL: ```bash /superheroes```
- Method: ```bash GET```
- Description: Retrives a list of all super heroes
- Response:
   ```bash
	[
	    {
	        "id": "5dfee45c-37e4-4442-80b2-6488a75d5b8c",
	        "name": "Ana",
	        "heroName": "Giant",
	        "birthDate": "12-12-2006",
	        "height": 300,
	        "weight": 78,
	        "superPowerIds": [
	            "2d3183fd-a6c5-4b14-a7cf-5fb1b15e5f19"
	        ],
	        "superPowerName": [
	            "Strength"
	        ]
	    },
		  ...
	]


**Get super hero by ID**

- URL: ```bash /superheroes/{id}```
- Method: ```bash GET```
- Description: Retrives a super hero by Id
- Response:
   ```bash
	{
	    "id": "74a02d99-cbab-48d0-99ed-a192eeeaa0da",
	    "name": "Mari",
	    "heroName": "Dra. Mari",
	    "birthDate": "01-12-2001",
	    "height": 157,
	    "weight": 65,
	    "superPowerIds": [
	        "09fbaeb0-a0e6-4b01-a14b-98ae91052b0d"
	    ],
	    	"superPowerName": [
	        	"Fly"
	    ]
	}


**Create a super hero**

- URL: ```bash /superheroes```
- Method: ```bash POST```
- Description: Creeates a new super hero
- Response:
   ```bash
	{
	  "name": "string",
	  "heroName": "string",
	  "birthDate": "2024-12-12T11:38:08.677Z",
	  "height": 0,
	  "weight": 0,
	  "superPowerIds": [
	    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
	  ]
	}


**Update a super hero**

- URL: ```bash /superheroes/{id}```
- Method: ```bash PUT```
- Description: Updates a existing super hero
- Response:
   ```bash
	{
	  "name": "string",
	  "heroName": "string",
	  "birthDate": "2024-12-12T11:38:08.677Z",
	  "height": 0,
	  "weight": 0,
	  ]
	}


**Delete a super hero**

- URL: ```bash /superheroes/{id}```
- Method: ```bash DELETE```
- Description: Delete a super hero by their ID
- Response:  ```bash 204 No Content```

---

### Error Handling

The API uses standard HTTP status codes to indicate the success or failure of an API request. Here are some common status codes:
   ```bash

200 OK: The request was successful.

201 Created: The resource was successfully created.

400 Bad Request: The request was invalid or cannot be served.

404 Not Found: The requested resource could not be found.

500 Internal Server Error: An error occurred on the server.


