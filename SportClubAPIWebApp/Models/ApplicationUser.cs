using Microsoft.AspNetCore.Identity;

namespace SportClubAPIWebApp.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        
        public string FullName { get; set; } = null!;


        public virtual ClientProfile? ClientProfile { get; set; }
        public virtual TrainerProfile? TrainerProfile { get; set; }
    }
}
