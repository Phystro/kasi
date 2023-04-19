namespace Kasi.Web.Client.Models
{
    public class DriverModel
    {
        public DriverModel(int id, string name, string country, string racingNumber, int teamId, Team? team)
        {
            Id = id;
            Name = name;
            Country = country;
            RacingNumber = racingNumber;
            TeamId = teamId;
            Team = team;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string RacingNumber { get; set; } = string.Empty;
        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}