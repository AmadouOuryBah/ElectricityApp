
namespace Electricity.DataAccess.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public double BuildingArea { get; set; }
        public int RenterId { get; set; }
        public  Renter Renter { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Resource> Resources{ get; set; }
       
    }
}
