namespace Kasi.Domain.DTO.DriverDTO
{
	public class DriverResponse : BaseEntity
	{
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string RacingNumber { get; set; } = string.Empty;

        public string TeamName { get; set; } = string.Empty;
	}
}