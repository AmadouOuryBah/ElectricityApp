using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IHeatMeterService
    {
        Task<List<HeatMeterDto>> GetAllAsync();
        Task<HeatMeterDto> GetById(int id);
        Task<HeatMeterDto> AddAsync(HeatMeterRequest heatMeter);
        Task<HeatMeterDto> UpdateAsync(HeatMeterDto heatMeter);
        Task<string> DeleteAsync(int id);
    }
}
