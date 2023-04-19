using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kasi.Domain.DTO.DriverDTO
{
	public class DriverRequest
	{
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string RacingNumber { get; set; } = string.Empty;
        
        public string TeamId { get; set; } = string.Empty;
	}
}