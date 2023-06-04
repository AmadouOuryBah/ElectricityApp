
namespace Electricity.DataAccess.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
