namespace Kasi.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DriverService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DriverResponse> CreateAsync(DriverRequest request)
        {
            // if(!ModelState.IsValid) return new JsonResult("Something Went Wrong"){StatusCode = 500};

            Team? team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.TeamId);

            Driver _driver = _mapper.Map<Driver>(request);
            _driver.Team = team;
            _context.Drivers.Add(_driver);

            await _context.SaveChangesAsync();

            DriverResponse driverResponse = _mapper.Map<DriverResponse>(_driver);
            return driverResponse;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Driver _driver = new () { Id = id };
            _context.Drivers.Remove(_driver);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<DriverResponse>> QueryAsync()
        {
            IEnumerable<Driver> _drivers = await _context.Drivers.Include(x => x.Team).ToListAsync();

            IEnumerable<DriverResponse> driverResponseList = _mapper.Map<IEnumerable<DriverResponse>>(_drivers);

            return driverResponseList;
        }

        public async Task<DriverResponse?> ReadAsync(string id)
        {
            Driver? _driver = await _context.Drivers.AsNoTracking().Include(x => x.Team).FirstOrDefaultAsync(x => x.Id == id);
            if(_driver is null) return null;

            DriverResponse driverResponse = _mapper.Map<DriverResponse>(_driver);
            return driverResponse;
        }

        public async Task<DriverResponse?> UpdateAsync(string id, DriverRequest request)
        {
            Driver? _driver = await _context.Drivers.FindAsync(id);
            if(_driver is null) return null;

            _driver.FirstName = request.FirstName;
            _driver.LastName = request.LastName;
            _driver.RacingNumber = request.RacingNumber;
            _driver.Country = request.Country;
            _driver.TeamId = request.TeamId;

            await _context.SaveChangesAsync();

            DriverResponse driverResponse = _mapper.Map<DriverResponse>(_driver);
            return driverResponse;
        }
    }
}
