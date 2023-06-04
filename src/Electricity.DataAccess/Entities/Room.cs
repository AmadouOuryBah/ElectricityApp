
namespace Electricity.DataAccess.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RoomArea { get; set; }
        public double TotalWorkers { get; set; }
        
        public double Area { get; set; }
        
        public DateOnly ArrivalDate { get; set; }
        
        public  DateOnly LeavingDate { get; set; }
        
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<RoomElectricalEquipement> RoomElectricalEquipements { get; set; }


    }
}
