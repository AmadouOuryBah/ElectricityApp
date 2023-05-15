
namespace Electricity.BusinessLogic.DTO_s
{
    public class RoomElectricalEquipementDto
    {
        public int Id { get; set; }
        public int RoomId { get;set;}
        public RoomDto Room { get; set; }
        public int WorkingTime { get; set; }
       public int ElectricalEquipementId { get; set; }
        public ElectricalEquipementDto ElectricalEquipement { get; set; }   



    }
}
