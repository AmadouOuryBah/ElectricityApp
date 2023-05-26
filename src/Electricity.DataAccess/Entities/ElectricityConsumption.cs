
namespace Electricity.DataAccess.Entities
{
    public class ElectricityConsumption
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public string Ressource { get; set; }

        public int  BuildingId { get; set; }
        
        public Building Building { get; set; }
        public double Quantity { get; set; }

    }
}
