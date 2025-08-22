# Appointment Service with Minimal APIs and Vertical Slice Architecture

This implementation demonstrates how to build a microservice using Minimal APIs and Vertical Slice Architecture with Clean Code principles.

## Features Implemented

1. **Minimal API** - Using the new minimal hosting model in .NET 8
2. **Vertical Slice Architecture** - Organizing code by features rather than technical layers
3. **Entity Framework Core** - With in-memory database for simplicity
4. **Swagger/OpenAPI** - For API documentation and testing

## Project Structure

```
AppointmentService/
│
├── Features/
│   └── CreateAppointment/
│       ├── CreateAppointmentDto.cs
│       └── CreateAppointmentHandler.cs
├── Data/
│   └── Appointment.cs
├── Program.cs
└── AppointmentService.csproj
```

## Key Concepts Demonstrated

### 1. Vertical Slice Architecture

The project is organized by features rather than technical layers. Each feature (like creating an appointment) contains all the code needed for that feature:
- DTOs for request/response
- Handler for business logic
- Any other supporting code

This approach:
- Reduces coupling between features
- Makes it easier to understand and maintain code
- Follows the principle of "things that change together should be grouped together"

### 2. Minimal APIs

Using .NET 8's Minimal API approach:
- Reduced boilerplate code
- Direct mapping of endpoints to handler code
- Simplified dependency injection

### 3. Clean Code Principles

- Single responsibility for each class
- Clear naming conventions
- Immutable records for DTOs
- Proper error handling

## How to Run

1. Navigate to the AppointmentService directory
2. Run `dotnet restore` to restore packages
3. Run `dotnet run` to start the service
4. Access the API at `http://localhost:5000`
5. View API documentation at `http://localhost:5000/swagger`

## API Endpoints

- `POST /api/appointments` - Create a new appointment

## Next Steps

To build upon this foundation:

1. Add more vertical slices for other operations (Get, Update, Delete)
2. Implement proper validation
3. Add unit and integration tests
4. Implement event publishing for event-driven architecture
5. Replace in-memory database with a real database
6. Add Dockerfile for containerization
7. Implement authentication and authorization