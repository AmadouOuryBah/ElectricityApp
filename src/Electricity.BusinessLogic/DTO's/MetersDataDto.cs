using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.DTO_s
{
    public class MetersDataDto
    {
        public int Id { get; set; }
        public int MeterId { get; set; }
        public DateTime Date { get; set; }
        public string Indication { get; set; }
    }
}
