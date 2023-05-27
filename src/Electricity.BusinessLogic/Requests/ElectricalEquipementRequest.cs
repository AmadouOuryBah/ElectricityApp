

using Electricity.BusinessLogic.DTO_s;

namespace Electricity.BusinessLogic.Requests
{
    public class ElectricalEquipementRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public double Coefficient { get; set; }
       
    }
}
