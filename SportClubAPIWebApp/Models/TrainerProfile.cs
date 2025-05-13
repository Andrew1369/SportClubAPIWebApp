using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportClubAPIWebApp.Models
{
    public class TrainerProfile
    {
        [Key, ForeignKey(nameof(User))]
        public Guid UserId { get; set; }               
        public ApplicationUser User { get; set; } = null!;

        public string Specialization { get; set; } = null!;
        public double Rating { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
