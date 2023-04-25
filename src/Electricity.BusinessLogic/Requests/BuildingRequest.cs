using Electricity.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Requests
{
    public class BuildingRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ElectricityMeterId { get; set; }
        public int HeatMeterId { get; set; }
        public int WaterMeterId { get; set; }
        public double BuildingArea { get; set; }
       
    }
}
