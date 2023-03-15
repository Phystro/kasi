using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> QueryAsync();
        Task<Team> CreateAsync(Team team);
    }
}