

using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.DTO_s
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sun { get; set; }
        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }
        public bool Sat { get; set; }
        public int TotalHours { get; set; }
        public ICollection<RoomDto> Rooms { get; set; }


    }
}
