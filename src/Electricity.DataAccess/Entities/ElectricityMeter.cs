
namespace Electricity.DataAccess.Entities
{
    public class ElectricityMeter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryNumber { get; set; }

        public ICollection<Building> Building { get; set; }


    }
}
