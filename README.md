# 📝 Notes API (Backend)

## 📌 Overview
The **Notes API** is a RESTful backend service built with **ASP.NET Core Web API**.  
It provides endpoints for managing notes with full **CRUD operations** and integrates with **SQL Server using Dapper**.

This API is designed to support a frontend client (Vue.js) and demonstrates clean architecture and efficient database access.

---

## 🚀 Tech Stack

- ASP.NET Core Web API (.NET 6/7/8)
- C#
- Dapper (Micro ORM)
- SQL Server
- RESTful API Design

---

## 📂 Project Structure

# Run the API

```
dotnet restore

```

```

dotnet run

```

>API will run at:
>https://localhost:5001

> ***📡API Endpoints***

>🔹 Get All Notes

 ``` GET /api/notes ```
>🔹 Get By Id

 ``` GGET /api/notes/{id} ```
>🔹 Create Note

 ``` GET /api/notes/ ```
 >Request Body: 
```
 {
  "title": "My Note",
  "content": "This is content"
} 
```

> 🔹 Update Note
```PUT /api/notes/{id}```
> 🔹 Delete Note
```DELETE /api/notes/{id}```
