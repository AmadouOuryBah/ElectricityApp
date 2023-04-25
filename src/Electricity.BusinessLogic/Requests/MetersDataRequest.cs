namespace Electricity.BusinessLogic.Requests
{
    public class MetersDataRequest
    {
       
        public int MeterId { get; set; }
        public DateTime Date { get; set; }
        public string Indication { get; set; }
    }
}
