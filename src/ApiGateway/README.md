# API Gateway

The API Gateway routes requests to the appropriate microservices and handles cross-cutting concerns.

## Features

- Request routing to downstream services
- Authentication and authorization
- Rate limiting
- Logging and monitoring
- Response aggregation (if needed)

## Routes

- `/api/appointments/*` -> Appointment Service
- `/api/notifications/*` -> Notification Service

## Technology Stack

- .NET 8
- YARP (Yet Another Reverse Proxy) or Ocelot
- JWT for authentication

## Configuration

The gateway is configured through `appsettings.json` to define routes and policies.