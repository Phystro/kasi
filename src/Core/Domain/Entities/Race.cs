namespace Kasi.Domain.Entities
{
    public class Race : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public ICollection<Team>? Teams { get; set; }

        public ICollection<TeamPoints> TeamPoints { get; set; }
        public ICollection<DriverPoints> DriverPoints { get; set; }

        public string SeasonId { get; set; } = string.Empty;
        public Season Season { get; set; }
    }
}
