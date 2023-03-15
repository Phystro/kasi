using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Domain.Entities
{
    public class DriverPoints
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}