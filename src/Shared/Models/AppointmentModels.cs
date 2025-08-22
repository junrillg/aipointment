using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public DateTime StartDateTime { get; set; }
        
        [Required]
        public DateTime EndDateTime { get; set; }
        
        [Required]
        public string Organizer { get; set; } = string.Empty;
        
        public List<Attendee> Attendees { get; set; } = new List<Attendee>();
        
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
    
    public class Attendee
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
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
    
    public class AppointmentCreatedEvent
    {
        public int AppointmentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public List<Attendee> Attendees { get; set; } = new List<Attendee>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    
    public class AppointmentCancelledEvent
    {
        public int AppointmentId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime CancelledAt { get; set; } = DateTime.UtcNow;
    }
}