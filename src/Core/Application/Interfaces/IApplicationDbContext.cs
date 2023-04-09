namespace Kasi.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Driver> Drivers { get; }
        Task<int> SaveToDatabase();
    }
}