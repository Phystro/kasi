namespace Kasi.Application.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponse>> QueryAsync();
        Task<TeamResponse?> ReadAsync(string id);
        Task<TeamResponse> CreateAsync(TeamRequest request);
        Task<TeamResponse?> UpdateAsync(string id, TeamRequest request);
        Task<bool> DeleteAsync(string id);
    }
}