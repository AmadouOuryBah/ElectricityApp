
namespace Electricity.DataAccess.Entities
{
    public class ElectricalMeter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public double Coefficient { get; set; }
        public int NumberOfDevice { get; set; }
        public int  Time { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        
    }
}
