using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Domain.Entities
{
    public class Team
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public ICollection<Driver> Drivers { get; set; }
        public ICollection<TeamPoints> TeamPoints { get; set; }
    }
}