

namespace Electricity.BusinessLogic.DTO_s
{
    public class ElectricityConsumptionDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Ressource { get; set; }
        public int BuildingId { get; set; }
        public BuildingDto Building { get; set; }
        public double Quantity { get; set; }
    }
}
