using AppointmentService.Features.CreateAppointment;

namespace AppointmentService.Endpoints;

public static class AppointmentEndpoints
{
    
    public static WebApplication MapAppointmentEndpoints(this WebApplication app)
    {
        
        var appointments = app.MapGroup("/api/appointments");

        appointments.MapPost("/", async (CreateAppointmentRequest request, CreateAppointmentHandler handler) =>
            {
                try
                {
                    var result = await handler.Handle(request);
                    return Results.Created($"/api/appointments/{result.Id}", result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithName("CreateAppointment");

        return app;
    }
}