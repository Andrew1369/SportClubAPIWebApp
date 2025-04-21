using System.ComponentModel.DataAnnotations.Schema;

namespace SportClubAPIWebApp.Models
{
    public enum EnrollmentStatus
    {
        Registered,    // Записаний
        Attended,      // Був
        NoShow,        // Неявка
        Canceled       // Скасовано
    }

    public class Enrollment
    {
        public Guid EnrollmentId { get; set; }            // PK

        public Guid SessionId { get; set; }               // FK → Session
        public Session Session { get; set; } = null!;

        public Guid ClientId { get; set; }             // FK → ClientProfile.UserId
        [ForeignKey(nameof(ClientId))]
        public ClientProfile Client { get; set; } = null!;

        public EnrollmentStatus Status { get; set; }
        public string? Feedback { get; set; }
        public bool PenaltyFlag { get; set; }
    }
}
