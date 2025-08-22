using AppointmentService.Data;
using AppointmentService.Endpoints;
using AppointmentService.Features.CreateAppointment;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentContext>(options =>
    options.UseInMemoryDatabase("AppointmentDatabase"));

builder.Services.AddScoped<CreateAppointmentHandler>();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapAppointmentEndpoints();

app.Run();