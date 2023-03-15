using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> QueryAsync();
        Task<Driver> CreateAsync(Driver driver);
    }
}