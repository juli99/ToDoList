# Todo List App

A full-stack task management application built with **ASP.NET Core 10** (backend) and **React + TypeScript** (frontend).

---

## Features

- Organize tasks into **Lists** grouped by **Categories**
- Create, edit, delete, and complete tasks
- Rename and delete lists
- Search for any task by ID
- Data persisted in a local **SQLite** database
- REST API documented with **Swagger UI**

---

## Project Structure

```
TodoApi/          ← ASP.NET Core Web API
├── Controllers/
│   ├── CategoriesController.cs
│   ├── TodoListsController.cs
│   └── TodoController.cs
├── Models/
│   ├── Category.cs
│   ├── TodoList.cs
│   ├── TodoItem.cs
│   └── TodoContext.cs
├── Migrations/
├── Program.cs
└── todo.db       ← SQLite database (auto-created)

todo-ui/          ← React TypeScript frontend
└── src/
    └── App.tsx
```

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org)

### 1. Run the Backend

```bash
cd TodoApi
dotnet run
```

API will be available at: `http://localhost:5096`  
Swagger UI: `http://localhost:5096/swagger`

> The SQLite database (`todo.db`) is created automatically on first run.

### 2. Run the Frontend

```bash
cd todo-ui
npm install
npm start
```

App will open at: `http://localhost:3000`

---

## API Reference

### Categories

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/categories` | Get all categories (with their lists) |
| GET | `/api/categories/{id}` | Get category by ID |
| POST | `/api/categories` | Create a new category |
| PUT | `/api/categories/{id}` | Update category name |
| DELETE | `/api/categories/{id}` | Delete a category |

### Lists

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/todolists` | Get all lists |
| GET | `/api/todolists/{id}` | Get list by ID (includes tasks) |
| POST | `/api/todolists` | Create a new list |
| PUT | `/api/todolists/{id}` | Rename a list / change category |
| DELETE | `/api/todolists/{id}` | Delete a list |

### Tasks

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/todo` | Get all tasks |
| GET | `/api/todo?listId={id}` | Get tasks filtered by list |
| GET | `/api/todo/{id}` | Get task by ID |
| POST | `/api/todo` | Create a new task |
| PUT | `/api/todo/{id}` | Update a task |
| DELETE | `/api/todo/{id}` | Delete a task |

#### Task object example

```json
{
  "id": 1,
  "title": "Buy groceries",
  "isCompleted": false,
  "createdAt": "2026-05-29T18:00:00",
  "listId": 2
}
```

---

## Tech Stack

| Layer | Technology |
|-------|------------|
| Backend | ASP.NET Core 10, C# |
| ORM | Entity Framework Core 10 |
| Database | SQLite |
| API Docs | Swagger (Swashbuckle) |
| Frontend | React 18, TypeScript |
