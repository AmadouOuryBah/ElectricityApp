using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IMetersDataService
    {
        Task<List<MetersDataDto>> GetAllAsync();
        Task<MetersDataDto> GetById(int id);
        Task<MetersDataDto> AddAsync(MetersDataRequest metersData);
        Task<MetersDataDto> UpdateAsync(MetersDataDto metersData);
        Task<string> DeleteAsync(int id);
    }
}
