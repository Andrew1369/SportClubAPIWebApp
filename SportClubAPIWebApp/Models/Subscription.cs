using System.ComponentModel.DataAnnotations.Schema;

namespace SportClubAPIWebApp.Models
{
    public enum SubscriptionType
    {
        Group,
        Individual,
        Unlimited
    }
    public class Subscription
    {
        public Guid SubscriptionId { get; set; }          // PK

        public Guid ClientId { get; set; }             // FK → ClientProfile.UserId
        [ForeignKey(nameof(ClientId))]
        public ClientProfile Client { get; set; } = null!;

        public SubscriptionType Type { get; set; }                
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingSessions { get; set; }
    }
}
