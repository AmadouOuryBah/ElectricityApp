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
        public int Floor { get; set; }
        public string City { get; set; }
     
    }
}
