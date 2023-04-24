namespace Kasi.Application.Profiles
{
	public class DriverProfile: Profile
	{
		public DriverProfile()
		{
			CreateMap<DriverRequest, Driver>()
				.ForMember(
						dest => dest.Id,
						opt => opt.MapFrom(
								src => Guid.NewGuid().ToString()
							)
					)
				.ForMember(
						dest => dest.FirstName,
						opt => opt.MapFrom(
								src => src.FirstName
							)
					)
				.ForMember(
						dest => dest.LastName,
						opt => opt.MapFrom(
								src => src.LastName
							)
					)
				.ForMember(
						dest => dest.Country,
						opt => opt.MapFrom(
								src => src.Country
							)
					)
				.ForMember(
						dest => dest.RacingNumber,
						opt => opt.MapFrom(
								src => src.RacingNumber
							)
					)
				.ForMember(
						dest => dest.TeamId,
						opt => opt.MapFrom(
								src => src.TeamId
							)
					)
				.ForMember(
						dest => dest.Team,
						opt => opt.MapFrom(
								src => new Team()
							)
					)
				;

			CreateMap<Driver, DriverResponse>()
				.ForMember(
					dest => dest.Id,
					opt => opt.MapFrom(
							x => x.Id
						)
					)
				.ForMember(
					dest => dest.FirstName,
					opt => opt.MapFrom(
							x => x.FirstName
						)
					)
				.ForMember(
					dest => dest.LastName,
					opt => opt.MapFrom(
							x => x.LastName
						)
					)
				.ForMember(
					dest => dest.FullName,
					opt => opt.MapFrom(
							x => $"{x.FirstName} {x.LastName}"
						)
					)
				.ForMember(
					dest => dest.Country,
					opt => opt.MapFrom(
							x => x.Country
						)
					)
				.ForMember(
					dest => dest.RacingNumber,
					opt => opt.MapFrom(
							x => x.RacingNumber
						)
					)
				.ForMember(
					dest => dest.TeamId,
					opt => opt.MapFrom(
							x => x.Team!.Id
						)
					)
				.ForMember(
					dest => dest.TeamName,
					opt => opt.MapFrom(
							x => x.Team!.Name
						)
					)
				;
		}
	}
}
