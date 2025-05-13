using System.ComponentModel.DataAnnotations.Schema;

namespace SportClubAPIWebApp.Models
{
    public class Session
    {
        public Guid SessionId { get; set; }            

        public Guid TrainerId { get; set; }           
        [ForeignKey(nameof(TrainerId))]
        public TrainerProfile Trainer { get; set; } = null!;

        public int ActivityTypeId { get; set; }        
        public ActivityType ActivityType { get; set; } = null!;

        public DateTime DateTime { get; set; }
        public string Room { get; set; } = null!;
        public int MaxParticipants { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
