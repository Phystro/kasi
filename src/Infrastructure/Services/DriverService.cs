using Kasi.Domain.Entities;

namespace Kasi.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationDbContext _context;

        public DriverService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Driver> CreateAsync(Driver request)
        {
            _context.Drivers.Add(request);
            var res = await _context.SaveChangesAsync();

            Console.WriteLine($"\n On Create: Returns: {res} \n Happy Now");

            return request;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Driver driver = new () { Id = id };
            _context.Drivers.Remove(driver);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Driver>> QueryAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver?> ReadAsync(int id)
        {
            Driver? driver = await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return driver;
        }

        public async Task<Driver?> UpdateAsync(Driver request)
        {
            Driver? driver = await _context.Drivers.FindAsync(request.Id);
            if(driver is null) return null;

            driver.Name = request.Name;
            driver.RacingNumber = request.RacingNumber;
            driver.Country = request.Country;

            await _context.SaveChangesAsync();
            return driver;
        }
    }
}