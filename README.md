# User API ( Course-Microsoft-Back-End-Development .NET )

Welcome to the User API project! This API allows you to manage users with basic CRUD operations. The API is built using ASP.NET Core and leverages JWT authentication for secure access.

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Logging](#logging)
- [Validation](#validation)
- [License](#license)

## Features

- Retrieve a list of users or a specific user by ID
- Add a new user
- Update an existing user's details
- Remove a user by ID
- JWT-based authentication
- Middleware logging
- Model validation

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- A development environment like Visual Studio or VS Code

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/UserApi.git
   cd UserApi

## Running the Application
- To run the application, execute the following command in the project directory:
  ```bash
  dotnet run
  ```
- Or use
  ```bash
  dotnet watch run
  ```

## API Endpoints
1. GET /api/user
Retrieve a list of users or a specific user by ID.

Parameters
id (optional): The ID of the user to retrieve.

2. POST /api/user
Add a new user.

Request Body
```bash
json
{
  "id": "string",
  "name": "string"
}
```
3. PUT /api/user/{id}
Update an existing user's details.

Request Body
```bash
json
{
  "id": "string",
  "name": "string"
}
```
4. DELETE /api/user/{id}
Remove a user by ID.


## Logging
- The API includes middleware logging to capture and log information about incoming requests and responses. The logging middleware is configured directly in Program.cs and logs details such as request method, path, response status code, and processing time.

## Validation
- The User model includes data annotations for validation. The following rules are enforced:
- Id: Required
- Name: Required, must be between 2 and 100 characters long
- Invalid data will result in a 400 Bad Request response with details about the validation errors.

## License

By using this software, you agree to the following whimsical terms:

1. You shall enjoy using this software and have fun while doing so.
2. You may modify and share the software as long as you spread good vibes.
3. You acknowledge that Copilot is awesome and deserves a virtual high-five. 🤖✋
4. Any bugs or issues shall be treated with kindness and patience.

© 2025 Copilot

