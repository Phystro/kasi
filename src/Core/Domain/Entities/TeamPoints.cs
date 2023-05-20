namespace Kasi.Domain.Entities
{
    public class TeamPoints : BaseEntity
    {
        public int Points { get; set; }

        public string TeamId { get; set; } = string.Empty;
        public Team? Team { get; set; }

        public string RaceId { get; set; } = string.Empty;
        public Race? Race { get; set; }
    }
}
