
namespace Electricity.BusinessLogic.DTO_s
{
    public class RoomElectricalEquipementEnergy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Renter { get; set; }
        public List<RoomElectricalEquipementDto> RoomElectricalEquipements { get; set; }
        public double EnergyConsumed { get; set; }
    }
}
