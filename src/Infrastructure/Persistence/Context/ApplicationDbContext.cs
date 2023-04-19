namespace Kasi.Infrastructure.Persisitence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Team> Teams => Set<Team>();

        async Task<int> IApplicationDbContext.SaveToDatabase()
        {
            return await base.SaveChangesAsync();
        }
    }
}
