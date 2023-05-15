

using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.DTO_s
{
    public class ElectricalEquipementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public double Coefficient { get; set; }
        public ICollection<RoomElectricalEquipementDto> RoomElectricalEquipements { get; set; }
    }
}
