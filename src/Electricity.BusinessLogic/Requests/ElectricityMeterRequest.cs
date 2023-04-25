using Electricity.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Requests
{
    public class ElectricalMeterRequest
    {
        public string Name { get; set; }
        public double Power { get; set; }
        public double Coefficient { get; set; }
        public int NumberOfDevice { get; set; }
        public int Time { get; set; }
        public int RoomId { get; set; }

    }
}
