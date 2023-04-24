namespace Kasi.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
        
        public string RacingNumber { get; set; } = string.Empty;
        
        public string TeamId { get; set; } = string.Empty;
        public Team? Team { get; set; }
    }
}
