using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface ITeamPointsService
    {
        Task<IEnumerable<TeamPoints>> QueryAsync();
        Task<TeamPoints> CreateAsync(TeamPoints teamPoints);
    }
}