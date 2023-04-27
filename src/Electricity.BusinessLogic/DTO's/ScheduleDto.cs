

namespace Electricity.BusinessLogic.DTO_s
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public RoomDto Room { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalOfDay { get; set; }

        
    }
}
