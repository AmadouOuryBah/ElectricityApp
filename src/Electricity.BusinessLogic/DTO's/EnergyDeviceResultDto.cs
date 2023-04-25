using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.DTO_s
{
    public class EnergyDeviceResultDto
    {
        public int RoomName { get; set; }
        public string RenterName { get; set; }
        public double EnergyCumsumed { get; set; }
        public List<ElectricalMeterDto> ElectricalMeters { get; set; }
    }
}
