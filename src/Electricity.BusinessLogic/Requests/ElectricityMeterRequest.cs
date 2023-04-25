using Electricity.BusinessLogic.DTO_s;
using Electricity.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Requests
{
    public class ElectricityMeterRequest
    {
      
        public string Name { get; set; }
        public int FactoryNumber { get; set; }

    }
}
