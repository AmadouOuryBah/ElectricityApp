
namespace Electricity.BusinessLogic.Requests
{
    public  class FilterParameter
    {
        public int Year { get; set;}
        public int Month { get; set; }
        public string ResourceType { get; set; } 
        public int BuildingId { get; set; }
    }
}
