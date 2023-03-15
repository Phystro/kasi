using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasi.Domain.Entities
{
    public class TeamPoints
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}