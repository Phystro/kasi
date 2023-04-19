namespace Kasi.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Team> Teams { get; }
        DbSet<Driver> Drivers { get; }
        Task<int> SaveToDatabase();
    }
}