
## 🚀 Minimal API Clean Architecture Boilerplate

This is a .NET 9 Minimal API project using Clean Architecture, CQRS with MediatR, Repository Pattern, and Separated Endpoint Definitions. It provides a scalable and maintainable template for building enterprise-level APIs.

## 📁 Project Folder Structure

```bash
📦MinimalApiProject
├── 📂Application
│
├── 📂Domain
│   └── 📂Models
│       └── 📄Post.cs
│
├── 📂Infrastructure
│   ├── 📂Migrations
│   └── 📂Repositories
│       ├── 📄PostRepository.cs
│       └── 📄SocialDbContext.cs
│
├── 📂MinimalAPI
│   ├── 📂Abstractions
│   │   └── 📄IEndPointDefenation.cs
│   │
│   ├── 📂Extensions
│   │   └── 📄MinimalAPIExtensions.cs
│   │
│   ├── 📂PostEndPointDefenations
│   │   └── 📄PostEndPointDefenation.cs
│   │
│   ├── 📄Program.cs
│   ├── 📄MinimalAPI.http
│   ├── 📄appsettings.json
│   ├── 📄appsettings.Development.json
│   └── 📄launchSettings.json

```

## 🧠 Architecture

    Clean Architecture: Separation of Concerns (SoC) and Dependency Inversion.

    CQRS: Command Query Responsibility Segregation.

    MediatR: For decoupled communication between layers.

    Repository Pattern: Abstracts database access logic.

    Minimal API: Lightweight and high-performance HTTP APIs in .NET.

    Endpoint Separated: Organized per feature for scalability and maintainability.


 ## 🧰 Technologies Used

    ASP.NET Core 7/8 Minimal API

    MediatR

    Entity Framework Core

    Microsoft SQL Server


