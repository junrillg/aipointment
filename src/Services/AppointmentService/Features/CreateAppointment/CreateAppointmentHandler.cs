using AppointmentService.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.Features.CreateAppointment;

public class CreateAppointmentHandler
{
    private readonly AppointmentContext _context;

    public CreateAppointmentHandler(AppointmentContext context)
    {
        _context = context;
    }

    public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request)
    {
        var appointment = new Appointment
        {
            Title = request.Title,
            Description = request.Description,
            StartDateTime = request.StartDateTime,
            EndDateTime = request.EndDateTime,
            Organizer = request.Organizer,
            Attendees = request.Attendees.Select(a => new Attendee
            {
                Name = a.Name,
                Email = a.Email
            }).ToList(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return new CreateAppointmentResponse(appointment.Id, appointment.Title, appointment.CreatedAt);
    }
}