
namespace Electricity.BusinessLogic.Requests
{
    public class ElectricityConsumptionRequest
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Ressource { get; set; }
        public int BuildingId { get; set; }
        public double Quantity { get; set; }

    }
}
