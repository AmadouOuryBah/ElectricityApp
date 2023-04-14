using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.Requests
{
    public class RoomRequest
    {
        public int NumberOfRoom { get; set; }
        public int RenterId { get; set; }
        public int BuildingId { get; set; }

    }
}
