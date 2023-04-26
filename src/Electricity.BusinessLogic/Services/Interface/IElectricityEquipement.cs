using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IElectricityEquipement
    {
        Task<List<ElectricalEquipementDto>> GetAllAsync();
        Task<ElectricalEquipementDto> AddAsync(ElectricalEquipementRequest electricalEquipementRequest);
        Task<ElectricalEquipementDto> UpdateAsync(ElectricalEquipementDto electricalEquipement);
        Task<string> DeleteAsync(int id);

        Task<ElectricalEquipementDto?> GetByIdAsync(int id);
    }
}
