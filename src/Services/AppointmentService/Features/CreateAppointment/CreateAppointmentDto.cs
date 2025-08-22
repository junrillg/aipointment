namespace AppointmentService.Features.CreateAppointment;

public record CreateAppointmentRequest(
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string Organizer,
    List<AttendeeDto> Attendees);

public record AttendeeDto(string Name, string Email);

public record CreateAppointmentResponse(int Id, string Title, DateTime CreatedAt);