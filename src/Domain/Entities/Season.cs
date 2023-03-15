using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public ICollection<Race> Races { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}