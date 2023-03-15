using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface IDriverPointsService
    {
        Task<IEnumerable<Driver>> QueryAsync();
        Task<Driver> CreateAsync(DriverPoints driverPoints);
    }
}