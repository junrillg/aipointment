# Sample Implementation: Notification Service

This document outlines how we would implement the Notification Service to consume events from the Appointment Service.

## Features Planned

1. **RabbitMQ Consumer** for appointment events
2. **Email Service** for sending notifications
3. **REST API** for health checks and configuration
4. **Structured Logging** for monitoring
5. **Dependency Injection** for service registration

## Project Structure

```
NotificationService/
│
├── Controllers/
│   └── HealthController.cs
├── Services/
│   ├── RabbitMQConsumerService.cs
│   └── EmailService.cs
├── Program.cs
├── appsettings.json
└── NotificationService.csproj
```

## Key Components Explained

### 1. RabbitMQ Consumer Service (RabbitMQConsumerService.cs)

This service would:
- Connect to RabbitMQ
- Subscribe to appointment events
- Process events and trigger notifications
- Handle message acknowledgment and retries

### 2. Email Service (EmailService.cs)

This service would:
- Connect to an SMTP server
- Format and send email notifications
- Handle email templates
- Log sent notifications

### 3. Health Check Controller (HealthController.cs)

This controller would:
- Provide endpoint for health monitoring
- Report service status
- Check dependencies (RabbitMQ connection, SMTP server)

### 4. Service Registration (Program.cs)

This would:
- Configure dependency injection for all services
- Set up RabbitMQ connection
- Add health checks
- Configure logging

## Implementation Approach

### Event Consumption

The Notification Service would consume two types of events:
1. `AppointmentCreatedEvent` - Send invitations to attendees
2. `AppointmentCancelledEvent` - Send cancellation notices

### Message Processing

For each event received:
1. Parse the event data
2. Generate appropriate email content
3. Send emails to all attendees
4. Log the notification attempt
5. Acknowledge the message

### Error Handling

To ensure reliability:
1. Implement retry mechanism for failed email sends
2. Use dead-letter queues for repeatedly failing messages
3. Log all errors with detailed context
4. Implement circuit breaker for SMTP server issues

## Configuration

The service would be configured through `appsettings.json`:
- RabbitMQ connection details
- SMTP server settings
- Email templates
- Retry policies

## Docker Integration

The service would include a `Dockerfile` for containerization and would be added to our `docker-compose.yml` file.

## API Endpoints

- `GET /health` - Service health check
- `GET /metrics` - Performance metrics (optional)

## Next Steps

To implement this service:
1. Create the project structure
2. Implement RabbitMQ consumer
3. Create email service
4. Add health checks
5. Configure dependency injection
6. Create Dockerfile
7. Update docker-compose.yml