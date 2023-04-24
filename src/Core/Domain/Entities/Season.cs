namespace Kasi.Domain.Entities
{
    public class Season : BaseEntity
    {
        public int Year { get; set; }
        public ICollection<Team>? Teams { get; set; }
        public ICollection<Race>? Races { get; set; }
    }
}
