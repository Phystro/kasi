namespace Kasi.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<Driver> Drivers { get; set; }
    }
}