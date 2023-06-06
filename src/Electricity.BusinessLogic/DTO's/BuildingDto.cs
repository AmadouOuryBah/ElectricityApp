using Electricity.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.DTO_s
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int RenterId { get; set; }
        public RenterDto Renter {get; set; }
        public double BuildingArea { get; set; }
        public ICollection<RoomDto> Rooms { get; set; }
        public ICollection<ResourceDto> ResourcesType { get; set; }
    }
}
