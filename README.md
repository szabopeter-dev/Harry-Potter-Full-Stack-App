# Harry Potter Full-Stack App

University assignment: a layered .NET full-stack application with multiple
client front-ends, a Harry-Potter-themed CRUD + non-CRUD domain (Houses,
Students, Subjects, Teachers).

## Architecture

| Project | Role |
|---|---|
| `Models` | Domain entities (House, Student, Subject, Teacher) |
| `Repository` | EF Core, generic + per-model repositories, SQL Server |
| `Logic` | Service interfaces + implementations |
| `Endpoint` | ASP.NET Core Web API + SignalR |
| `Client` | Console REST client |
| `JSClient` | Razor + JS web client |
| `WPFClient` | WPF desktop client (MVVM) |
| `Test` | NUnit + Moq unit tests |

Code-first EF migrations, async controllers, SignalR for live updates.

## API examples

```http
GET  /House
POST /House
GET  /Stat/GetStudentFromHouse/{name}      # non-CRUD aggregate
```

```json
{ "id": 0, "house_name": "TestHouse", "founder_name": "TestFounder", "house_points": 888 }
```

## Run

```bash
git clone https://github.com/szabopeter-dev/Harry-Potter-Full-Stack-App
cd Harry-Potter-Full-Stack-App
dotnet run --project FN738S_HFT_2023241.Endpoint
```

The Web API starts on the default Kestrel port; the WPF, JS, and console
clients can then be launched against it.
