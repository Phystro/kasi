namespace Kasi.Application.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> QueryAsync();
        Task<Driver?> ReadAsync(int id);
        Task<Driver> CreateAsync(Driver request);
        Task<Driver?> UpdateAsync(Driver request);
        Task<bool> DeleteAsync(int id);
    }
}