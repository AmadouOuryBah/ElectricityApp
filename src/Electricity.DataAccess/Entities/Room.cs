
namespace Electricity.DataAccess.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int NumberOfRoom { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public ICollection<ElectricalMeter> ElectricalMeters { get; set; }
    }
}
