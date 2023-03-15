using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface IRaceService
    {
        Task<IEnumerable<Race>> QueryAsync();
        Task<Race> CreateAsync(Race race);
    }
}