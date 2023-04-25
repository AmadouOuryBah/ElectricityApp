using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IElectricalEquipement
    {
        Task<List<ElectricalEquipementDto>> GetAllAsync();
        Task<ElectricalEquipementDto> AddAsync(ElectricalEquipementRequest electricalEquipementRequest);
        Task<ElectricalEquipementDto> UpdateAsync(int id, ElectricalEquipementRequest electricalEquipementRequest);
        Task<string> DeleteAsync(int id);
    }
}
