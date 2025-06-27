# Task Management API

A simple REST API for managing tasks built with .NET 8 and ASP.NET Core.

## Features

- Create, read, update, and delete tasks
- Task status management (Todo, In Progress, Complete)
- Task deadlines and descriptions
- CORS enabled for frontend integration
- Swagger documentation

## Quick Start

### Prerequisites
- .NET 8 SDK

### Run the API
```bash
dotnet run
```

The API will be available at:
- HTTP: `http://localhost:5206`
- HTTPS: `https://localhost:7237`
- Swagger UI: `https://localhost:7237/swagger`

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | `/api/tasks` | Get all tasks |
| GET    | `/api/tasks/{id}` | Get task by ID |
| POST   | `/api/tasks` | Create new task |
| PUT    | `/api/tasks/{id}` | Update task |
| DELETE | `/api/tasks/{id}` | Delete task |

## Task Model

```json
{
  "id": 1,
  "name": "Task Name",
  "description": "Task Description",
  "status": "Todo", // Todo, In Progress, Complete
  "deadline": "2025-07-01"
}
```

## Configuration

- **CORS**: Frontend origin configured in `appsettings.json`
- **Default CORS Origin**: `http://localhost:5173` (for React/Vite)

## Project Structure

```
├── Controllers/        # API controllers
├── DTOs/              # Data transfer objects
├── Models/            # Domain models
├── Services/          # Business logic
└── appsettings.json   # Configuration
```
