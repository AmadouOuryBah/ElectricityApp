

namespace Electricity.BusinessLogic.Requests
{
    public  class ScheduleRequest
    {
        public int RoomId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalOfDay { get; set; } 
    }
}
