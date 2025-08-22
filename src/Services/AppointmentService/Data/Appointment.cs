using Microsoft.EntityFrameworkCore;

namespace AppointmentService.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Organizer { get; set; } = string.Empty;
        public List<Attendee> Attendees { get; set; } = new List<Attendee>();
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Attendee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool HasConfirmed { get; set; } = false;
    }

    public enum AppointmentStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }

    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Attendee> Attendees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.Attendees)
                .WithOne()
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Title)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Organizer)
                .IsRequired();

            modelBuilder.Entity<Attendee>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder.Entity<Attendee>()
                .Property(a => a.Email)
                .IsRequired();
        }
    }
}