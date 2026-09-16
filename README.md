# Appointment Booking System

A simple appointment booking API built with **ASP.NET Core**, **Entity Framework Core**, and **PostgreSQL**.

The project is currently being developed as a learning project with a focus on:

* Object-oriented design and encapsulation
* Layered architecture
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Repository and service patterns
* Unit testing
* Docker-based database setup

## Project Structure

```text
AppointmentSystem
├── src
│   ├── AppointmentSystem.Api
│   │   ├── Configurations
│   │   └── Program.cs
│   │
│   ├── AppointmentSystem.Application
│   │   ├── DTOs
│   │   ├── Interfaces
│   │   └── Services
│   │
│   ├── AppointmentSystem.Domain
│   │   ├── Entities
│   │   └── Enums
│   │
│   └── AppointmentSystem.Infrastructure
│       └── Persistence
│
├── tests
│   └── AppointmentSystem.Tests
│
├── data
│   └── db
│
├── docker-compose.yml
└── AppointmentSystem.slnx
```

### Architecture

The project follows a simple layered structure:

```text
API
 ↓
Application
 ↓
Domain

Infrastructure
 ↓
PostgreSQL
```

* **API** — HTTP endpoints and application entry point.
* **Application** — Application services, DTOs, and repository abstractions.
* **Domain** — Core entities, enums, and business concepts.
* **Infrastructure** — Database access and EF Core persistence.
* **Tests** — Unit tests for application behavior.

## Tech Stack

* C#
* ASP.NET Core
* Entity Framework Core
* PostgreSQL
* Docker & Docker Compose
* xUnit
* .NET SDK

## Prerequisites

Make sure the following are installed:

* [.NET SDK](https://dotnet.microsoft.com/download)
* [Docker](https://docs.docker.com/engine/install/)
* Git

You can verify the installations with:

```bash
dotnet --version
docker --version
docker compose version
git --version
```

## Running Locally

### 1. Clone the repository

```bash
git clone https://github.com/dev-mitesh-patil/AppointmentBooking.git
cd AppointmentBooking
```

### 2. Start PostgreSQL

The project uses Docker Compose to run PostgreSQL and Adminer.

```bash
docker compose up -d
```

Check that the containers are running:

```bash
docker compose ps
```

You should see the PostgreSQL and Adminer services running.

### 3. Configure the database

The application connects to the PostgreSQL container through the host machine when running the API locally.

The connection string should use:

```text
Host=localhost
Port=5432
```

Make sure your local configuration contains the required database credentials.

### 4. Apply EF Core migrations

From the repository root:

```bash
dotnet ef database update \
  --project src/AppointmentSystem.Infrastructure \
  --startup-project src/AppointmentSystem.Api
```

If `dotnet ef` is not installed:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project src/AppointmentSystem.Api
```

The API will start on the URL shown in the terminal.

## Adminer

Adminer is included in Docker Compose for inspecting the PostgreSQL database.

Open:

```text
http://localhost:8080
```

Use the following connection details:

```text
System:   PostgreSQL
Server:   db
Port:     5432
Username: <DB_USER>
Password: <DB_PASSWORD>
Database: <DB_NAME>
```

> When connecting through Adminer, use `db` as the server name because Adminer runs inside the Docker network.

## Running Tests

Run all tests from the repository root:

```bash
dotnet test
```

## Useful Docker Commands

Start the database and Adminer:

```bash
docker compose up -d
```

View running containers:

```bash
docker compose ps
```

View database logs:

```bash
docker compose logs -f db
```

Stop the containers:

```bash
docker compose down
```

## Current Status

This project is currently under development.

The initial focus is on building a clean foundation for an appointment booking system before introducing additional infrastructure or production-level complexity.

Planned areas include:

* Doctor management
* Patient management
* Doctor availability
* Appointment creation and management
* Appointment status handling
* Validation and business rules
* More comprehensive automated tests

## License

This project is for learning and development purposes.
