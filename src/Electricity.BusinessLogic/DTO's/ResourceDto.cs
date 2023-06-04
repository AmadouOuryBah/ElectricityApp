

namespace Electricity.BusinessLogic.DTO_s
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string ResourceType { get; set; }
        public int BuildingId { get; set; }
        public BuildingDto Building { get; set; }
        public double Quantity { get; set; }
    }
}
