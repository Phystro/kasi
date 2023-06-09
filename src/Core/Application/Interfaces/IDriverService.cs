namespace Kasi.Application.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverResponse>> QueryAsync();
        Task<DriverResponse?> ReadAsync(string id);
        Task<DriverResponse> CreateAsync(DriverRequest request);
        Task<DriverResponse?> UpdateAsync(string id, DriverRequest request);
        Task<bool> DeleteAsync(string id);
    }
}