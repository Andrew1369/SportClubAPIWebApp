using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportClubAPIWebApp.Models
{
    public class ClientProfile
    {
        [Key, ForeignKey(nameof(User))]
        public Guid UserId { get; set; }             
        public ApplicationUser User { get; set; } = null!;

        public int BonusPoints { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
