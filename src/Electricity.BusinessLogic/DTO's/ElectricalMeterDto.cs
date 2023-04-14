

namespace Electricity.BusinessLogic.DTO_s
{
    public class ElectricalMeterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public double Coefficient { get; set; }
        public int NumberOfDevice { get; set; }
        public int Time { get; set; }
        public int RoomID { get; set; }
        public RoomDto Room { get; set; }

    }
}
