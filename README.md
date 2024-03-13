
# Harry Potter Full Stack App

This is an individual semester assignment that contains advanced c# knowledge.
With this project I learned about the following topics:
- Entity Framework Core
- Code-first approach
- SQL Server database connection
- Navigation Properties
- CRUD/NON CRUD Methods
- Asynchronous programming
- NUnit
- HTML/CSS/JS
- WPF

# Description

Its a Harry Potter themed project, you can add Teachers Students Subjects
to different Houses and call NON CRUD methods to get back some data. 
Nunit Moq tests included too.


## API Reference

#### Get all Houses

```http
  GET /House
```

#### Add new House

```http
  POST /House
```

Request body example:

{
  "id": 0,
  "house_name": "TestHouse",
  "founder_name": "TestFounder",
  "house_points": 888
}

#### Get Student From House (NON CRUD)

```http
  GET /Stat/GetStudentFromHouse/{name}
```
Response body example:

{
    "studentname": "TestResponse"
}

## Run Locally

Open terminal, 
Clone the project

```bash
  git clone https://github.com/szabopeter-dev/Harry-Potter-Full-Stack-App
```

Go to the project directory

```bash
  cd .\Harry-Potter-Full-Stack-App
```

Start the application

```bash
  dotnet run
```


2024 -- GUI added to my Full Stack App

