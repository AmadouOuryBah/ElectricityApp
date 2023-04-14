

using Electricity.DataAccess.Entities;
using System.Text.Json.Serialization;

namespace Electricity.BusinessLogic.DTO_s
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int NumberOfRoom { get; set; }
        public int RenterId { get; set; }
    
        public RenterDto Renter { get; set; }
        public int BuildingId { get; set; }
    
        public BuildingDto Building { get; set; }
        public ICollection<ElectricalMeterDto> ElectricalMeters { get; set; }
    }
}
