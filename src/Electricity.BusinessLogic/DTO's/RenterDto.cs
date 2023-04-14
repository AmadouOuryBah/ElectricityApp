

using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.DTO_s
{
    public class RenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomDto> Rooms { get; set; }
    }
}
