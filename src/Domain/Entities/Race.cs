using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Domain.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TeamPoints> TeamPoints { get; set; }
        public ICollection<DriverPoints> DriverPoints { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}