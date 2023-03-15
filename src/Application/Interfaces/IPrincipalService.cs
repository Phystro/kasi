using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Application.Interfaces
{
    public interface IPrincipalService
    {
        Task<IEnumerable<Principal>> QueryAsync();
        Task<Principal> CreateAsync(Principal principal);
    }
}