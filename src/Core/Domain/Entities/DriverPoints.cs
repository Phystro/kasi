namespace Kasi.Domain.Entities
{
    public class DriverPoints : BaseEntity
    {
        public int Points { get; set; }
        
        public string DriverId { get; set; } = string.Empty;
        public Driver Driver { get; set; }

        public string RaceId { get; set; } = string.Empty;
        public Race Race { get; set; }
    }
}
