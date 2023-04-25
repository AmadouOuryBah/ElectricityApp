using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.DataAccess.Entities
{
    public class WaterMeter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryNumber { get; set; }
    }
}
