namespace SportClubAPIWebApp.Models
{
    public class ActivityType
    {
        public Guid ActivityTypeId { get; set; }          
        public string Name { get; set; } = null!;           
        public bool IsGroup { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
