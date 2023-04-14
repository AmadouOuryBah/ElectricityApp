using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IBuilding
    {
        Task<List<BuildingDto>> GetAllAsync();
        Task<BuildingDto> AddAsync(BuildingRequest building);
        Task<BuildingDto> UpdateAsync(int id, BuildingRequest building);
        Task<string> DeleteAsync(int id);
    }
}
