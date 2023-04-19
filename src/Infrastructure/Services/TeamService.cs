namespace Kasi.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TeamService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamResponse> CreateAsync(TeamRequest request)
        {
        	Team _team = _mapper.Map<Team>(request);
            _context.Teams.Add(_team);

            await _context.SaveChangesAsync();

            TeamResponse teamResponse = _mapper.Map<TeamResponse>(_team);
            return teamResponse;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Team team = new () { Id = id };
            _context.Teams.Remove(team);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TeamResponse>> QueryAsync()
        {
        	IEnumerable<Team> _teams = await _context.Teams.ToListAsync();
        	IEnumerable<TeamResponse> teamResponseList = _mapper.Map<IEnumerable<TeamResponse>>(_teams);
        	return teamResponseList;
        }

        public async Task<TeamResponse?> ReadAsync(string id)
        {
            Team? _team = await _context.Teams.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(_team is null) return null;

            TeamResponse teamResponse = _mapper.Map<TeamResponse>(_team);
            return teamResponse;
        }

        public async Task<TeamResponse?> UpdateAsync(string id, TeamRequest request)
        {
            Team? _team = await _context.Teams.FindAsync(id);
            if(_team is null) return null;

            _team.Name = request.Name;
            _team.Alias = request.Alias;
            _team.Country = request.Country;

            await _context.SaveChangesAsync();

            TeamResponse teamResponse = _mapper.Map<TeamResponse>(_team);
            return teamResponse;
        }
    }
}