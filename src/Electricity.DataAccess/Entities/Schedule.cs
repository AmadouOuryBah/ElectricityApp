using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.DataAccess.Entities
{
    public  class Schedule
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalOfDay { get; set; }
    }
}
