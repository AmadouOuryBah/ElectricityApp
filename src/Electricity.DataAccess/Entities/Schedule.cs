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
        public string Name { get; set; }
        public bool Sun { get; set; }
        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }
        public bool Sat { get; set; }
        public int TotalHours { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
