namespace Electricity.DataAccess.Entities
{
    public  class RoomElectricalEquipement
    {
        public int Id { get; set; }
        public int WorkingTime { get; set; }

        public ICollection<ElectricalEquipment> ElectricalEquipments { get; set; }

    }
}
