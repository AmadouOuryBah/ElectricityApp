using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.Requests
{
    public class RoomRequest
    {
       
        public string Name { get; set; }
        public double RoomArea { get; set; }
        public double TotalWorkers { get; set; }
        public int BuildingId { get; set; }
        public int RenterId { get; set; }
        public int ScheduleId { get; set; }

        public DateTime ArrivalDate { get; set; }
        public DateTime LeavingDate { get; set; }



    }
}
