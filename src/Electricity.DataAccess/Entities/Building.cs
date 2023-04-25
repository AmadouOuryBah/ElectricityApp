
namespace Electricity.DataAccess.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ElectricityMeterId { get; set; }
        public ElectricityMeter ElectricityMeter { get; set; }
        public int HeatMeterId { get; set; }
        public HeatMeter HeatMeter { get; set; }
        public int WaterMeterId { get; set; }
        public WaterMeter WaterMeter { get; set; }
        public double BuildingArea { get; set; }

        public ICollection<Room> Rooms { get; set; }
       
    }
}
