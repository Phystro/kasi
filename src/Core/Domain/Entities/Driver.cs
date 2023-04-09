namespace Kasi.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string RacingNumber { get; set; } = string.Empty;
    }
}