

namespace Electricity.DataAccess.Entities
{
    public class MetersData
    {
        public int Id { get; set; }
        public int MeterId { get; set; }
        public DateTime Date { get; set; }
        public string Indication { get; set;}
    }
}
