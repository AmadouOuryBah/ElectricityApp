
namespace Electricity.DataAccess.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public string City { get; set; }
        public ICollection<Room> Rooms {get; set; }
    }
}
