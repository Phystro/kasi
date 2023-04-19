namespace Kasi.Infrastructure.Profiles
{
	public class TeamProfile: Profile
	{
		public TeamProfile()
		{
			CreateMap<TeamRequest, Team>()
				.ForMember(
						dest => dest.Id,
						opt => opt.MapFrom(
								src => Guid.NewGuid().ToString()
							)
					)
				.ForMember(
						dest => dest.Name,
						opt => opt.MapFrom(
								src => src.Name
							)
					)
				.ForMember(
						dest => dest.Alias,
						opt => opt.MapFrom(
								src => src.Alias
							)
					)
				.ForMember(
						dest => dest.Country,
						opt => opt.MapFrom(
								src => src.Country
							)
					)
				;

			CreateMap<Team, TeamResponse>()
				.ForMember(
					dest => dest.Id,
					opt => opt.MapFrom(
							x => x.Id
						)
					)
				.ForMember(
					dest => dest.Name,
					opt => opt.MapFrom(
							x => x.Name
						)
					)
				.ForMember(
					dest => dest.Alias,
					opt => opt.MapFrom(
							x => x.Alias
						)
					)
				.ForMember(
					dest => dest.Country,
					opt => opt.MapFrom(
							x => x.Country
						)
					)
				;
		}
	}
}