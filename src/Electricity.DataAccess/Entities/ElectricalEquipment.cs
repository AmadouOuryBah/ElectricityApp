
namespace Electricity.DataAccess.Entities
{
    public class ElectricalEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public double Coefficient { get; set; }

        public ICollection<RoomElectricalEquipement> RoomElectricalEquipements { get; set; }
    }
}
