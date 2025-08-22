# Notification Service

This service handles sending notifications for appointment events.

## Features

- Consume appointment events from the message broker
- Send email notifications to attendees
- Log notification attempts and results

## Event Consumption

- `AppointmentCreatedEvent` - Sends invitation emails
- `AppointmentCancelledEvent` - Sends cancellation notices

## Technology Stack

- .NET 8
- ASP.NET Core Web API
- RabbitMQ for event consumption
- SMTP client for email sending

## Configuration

The service requires SMTP server configuration for sending emails.