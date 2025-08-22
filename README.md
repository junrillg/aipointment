# AIpointment - Microservices & Event-Driven Architecture Learning Project

This project is designed as a hands-on learning experience to understand and implement microservices and event-driven architecture using .NET and Blazor UI. The goal is to build a simple appointment scheduling application while following industry best practices for production-ready systems.

## Project Structure

The solution is organized into the following structure:

```
aipointment/
│
├── aipointment.sln                    # Main solution file
├── docker-compose.yml                 # Docker Compose for running all services
├── README.md                          # This file
├── TASK_BREAKDOWN.md                  # Detailed task breakdown and learning plan
├── PROGRESS_SUMMARY.md                # Progress tracking
├── .idea/                             # IDE specific files
├── docs/                              # Documentation and learning notes
└── src/
    ├── ApiGateway/                    # API Gateway service
    │   ├── ApiGateway.csproj          # API Gateway project file
    │   ├── Dockerfile                 # Docker configuration
    │   └── Properties/                
    │       └── launchSettings.json    # Development settings
    ├── Services/
    │   ├── AppointmentService/        # Appointment management service
    │   │   ├── AppointmentService.csproj  # Project file
    │   │   ├── Dockerfile             # Docker configuration
    │   │   ├── Properties/            
    │   │   │   └── launchSettings.json # Development settings
    │   │   └── [Implementation files]
    │   └── NotificationService/       # Notification service
    │       ├── NotificationService.csproj  # Project file
    │       ├── Dockerfile             # Docker configuration
    │       ├── Properties/            
    │       │   └── launchSettings.json # Development settings
    │       └── [Implementation files]
    ├── Frontend/
    │   └── BlazorApp/                 # Blazor WebAssembly frontend
    │       ├── BlazorApp.csproj       # Frontend project file
    │       ├── Dockerfile             # Docker configuration
    │       ├── Properties/            
    │       │   └── launchSettings.json # Development settings
    │       └── [UI Implementation files]
    └── Shared/
        └── Models/                    # Shared models library
            └── Models.csproj          # Shared models project file
```

## Services Overview

1. **AppointmentService**: Core service for managing appointments with CRUD operations
2. **NotificationService**: Service for sending notifications about appointments
3. **ApiGateway**: Entry point for all client requests, routing to appropriate services
4. **BlazorApp**: Frontend application built with Blazor WebAssembly
5. **Models**: Shared library containing common data models

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Running with Docker Compose (Recommended)

This is the easiest way to run the complete system with all services:

```bash
# Navigate to the project root
cd aipointment

# Start all services
docker-compose up

# The services will be available at:
# Appointment Service: http://localhost:8080
# Notification Service: http://localhost:8081
# API Gateway: http://localhost:8000
# Blazor Frontend: http://localhost:8082
# RabbitMQ Management: http://localhost:15672 (guest/guest)
# PostgreSQL: localhost:5432 (postgres/password)
```

To stop all services:
```bash
# Press Ctrl+C in the terminal, or run:
docker-compose down
```

### Running from Visual Studio

1. Open `aipointment.sln` in Visual Studio
2. Set "docker-compose" as the startup project (found in the solution root)
3. Press F5 to run in debug mode

### Running from CLI

You can run individual services or all services from the command line:

```bash
# Restore all dependencies
dotnet restore

# Run all services in separate terminals:

# Terminal 1: Run Appointment Service
dotnet run --project src/Services/AppointmentService/AppointmentService.csproj

# Terminal 2: Run Notification Service
dotnet run --project src/Services/NotificationService/NotificationService.csproj

# Terminal 3: Run API Gateway
dotnet run --project src/ApiGateway/ApiGateway.csproj

# Terminal 4: Run Blazor Frontend
dotnet run --project src/Frontend/BlazorApp/BlazorApp.csproj
```

Services will be available at:
- Appointment Service: http://localhost:8080
- Notification Service: http://localhost:8081
- API Gateway: http://localhost:8000
- Blazor Frontend: http://localhost:8082

## Development Workflow

### Adding New Features

1. Identify the appropriate service for your feature
2. Follow the Vertical Slice Architecture pattern:
   - Create a folder for your feature in the service's Features directory
   - Implement the Minimal API endpoint
   - Create handlers for business logic
   - Add request/response models
   - Implement data access logic if needed
3. Add unit tests for your feature
4. Update documentation as needed

### Working with the Database

The Appointment Service uses PostgreSQL for data persistence:

1. Connection: `Server=appointment-db;Database=appointmentdb;User=postgres;Password=password;`
2. When running with Docker, the database is automatically provisioned
3. For local development, you can use the in-memory database or a local PostgreSQL instance

### Working with Events

The system uses RabbitMQ for event-driven communication:

1. Events are published by the Appointment Service when appointments are created/updated/deleted
2. The Notification Service consumes these events to send notifications
3. RabbitMQ Management UI is available at http://localhost:15672 (guest/guest)

## Project Goals

1. **Learn Microservices Architecture**: Understand how to decompose a monolithic application into smaller, independent services.
2. **Implement Event-Driven Architecture**: Learn how services communicate asynchronously through events.
3. **Use .NET Technologies**: Utilize .NET for backend services and Blazor for the frontend UI.
4. **Follow Best Practices**: Apply industry-standard patterns and practices for building production-ready microservices.
5. **Complete in Stages**: Follow the structured learning plan in [TASK_BREAKDOWN.md](TASK_BREAKDOWN.md) to build the system incrementally.

## Technology Stack

- **Backend**: .NET 8+ (C#) with Minimal APIs
- **Frontend**: Blazor WebAssembly
- **Messaging**: RabbitMQ
- **Database**: PostgreSQL
- **Containerization**: Docker
- **Orchestration**: Docker Compose
- **API Gateway**: Custom .NET API Gateway with YARP
- **Architecture**: Microservices with Event-Driven Communication

## Learning Resources

### Books
1. **Building Microservices** by Sam Newman
   - [Amazon Link](https://www.amazon.com/Building-Microservices-Designing-Fine-Grained-Systems/dp/1492034029)
   - A comprehensive guide to designing and building microservices.

2. **Microservices Patterns** by Chris Richardson
   - [Amazon Link](https://www.amazon.com/Microservices-Patterns-examples-Chris-Richardson/dp/1617294543)
   - Practical guide with patterns and best practices for microservices.

3. **Clean Architecture** by Robert C. Martin
   - [Amazon Link](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164)
   - Principles of clean architecture and design.

4. **Designing Data-Intensive Applications** by Martin Kleppmann
   - [Amazon Link](https://www.amazon.com/Designing-Data-Intensive-Applications-Reliable-Maintainable/dp/1449373321)
   - Deep dive into systems that store and process data.

### Online Resources

1. **Microsoft Documentation - Microservices**
   - [Microsoft Learn - Microservices](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/)
   - Official guide from Microsoft on building microservices with .NET.

2. **Microsoft Documentation - Minimal APIs**
   - [Minimal APIs in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)
   - Official documentation for building lightweight APIs with .NET.

3. **Blazor Documentation**
   - [Microsoft Learn - Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
   - Official documentation for building web UIs with Blazor.

4. **RabbitMQ Tutorials**
   - [RabbitMQ Tutorials](https://www.rabbitmq.com/getstarted.html)
   - Hands-on tutorials for implementing messaging with RabbitMQ.

5. **Azure Architecture Center**
   - [Azure Architecture Patterns](https://learn.microsoft.com/en-us/azure/architecture/patterns/)
   - Comprehensive guide to cloud design patterns.

### Courses

1. **Microservices Architecture & Implementation on .NET**
   - [Udemy Course](https://www.udemy.com/course/microservices-architecture-dotnet-core/)
   - Comprehensive course on building microservices with .NET.

2. **Blazor Server & WebAssembly Course**
   - [Udemy Course](https://www.udemy.com/course/blazor-server-and-webassembly-course/)
   - Learn to build modern web applications with Blazor.

3. **.NET Microservices - Full Course**
   - [Microsoft Learn](https://learn.microsoft.com/en-us/training/modules/dotnet-microservices-architecture/)
   - Free official course on .NET microservices.

### Architecture Patterns

1. **Vertical Slice Architecture**
   - [Jimmy Bogard on Vertical Slices](https://www.youtube.com/watch?v=5kOz9JwgmaU)
   - Video explaining the vertical slice approach to application architecture.

2. **Event-Driven Architecture**
   - [Event-Driven Architecture Patterns](https://learn.microsoft.com/en-us/azure/architecture/guide/architecture-styles/event-driven)
   - Microsoft's guide to event-driven systems.

3. **API Gateway Pattern**
   - [API Gateway Pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/gateway)
   - Explanation of the API Gateway pattern and its benefits.

## Contributing

This project is for learning purposes. Contributions are welcome in the form of suggestions, improvements, or additional features that align with the learning objectives.

## Next Steps

Follow the structured learning plan in [COMBINED_TASK_PLAN.md](COMBINED_TASK_PLAN.md) to implement the complete system with all features and patterns. This combined plan merges our progress tracking with detailed implementation tasks for a clearer view of what needs to be done next.