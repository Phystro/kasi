using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface ISeasonService
    {
        Task<IEnumerable<Season>> QueryAsync();
        Task<Season> CreateAsync(Season season);
    }
}