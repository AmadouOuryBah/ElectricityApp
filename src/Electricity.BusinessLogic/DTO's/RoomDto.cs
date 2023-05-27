using Electricity.DataAccess.Entities;
using System.Text.Json.Serialization;

namespace Electricity.BusinessLogic.DTO_s
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public double RoomArea { get; set; }
        public double TotalWorkers { get; set; }
        public int BuildingId { get; set; }
        public BuildingDto Building { get; set; }
        public int RenterId { get; set; }
        public RenterDto Renter { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleDto Schedule { get; set; }

    }
}
