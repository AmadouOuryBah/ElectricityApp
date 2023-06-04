namespace Electricity.DataAccess.Entities
{
    public  class RoomElectricalEquipement
    {
        public int Id { get; set; }
        public int WorkingTime { get; set; }
        public int Quantity { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int ElectricalEquipementId { get; set; }
        public ElectricalEquipement ElectricalEquipement { get; set; }

       
    }
}
