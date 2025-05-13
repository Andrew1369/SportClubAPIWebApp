using System.ComponentModel.DataAnnotations.Schema;

namespace SportClubAPIWebApp.Models
{
    public enum SubscriptionType
    {
        Group,        //Груповий
        Individual,   //Індивідуальний
        Unlimited     //Безліміт
    }
    public class Subscription
    {
        public Guid SubscriptionId { get; set; }         

        public Guid ClientId { get; set; }            
        [ForeignKey(nameof(ClientId))]
        public ClientProfile Client { get; set; } = null!;

        public SubscriptionType Type { get; set; }                
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingSessions { get; set; }
    }
}
