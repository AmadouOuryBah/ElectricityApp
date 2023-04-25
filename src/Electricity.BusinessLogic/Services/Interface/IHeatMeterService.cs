using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IHeatMeterService
    {
        Task<List<HeatMetreDto>> GetAllAsync();
        Task<HeatMeterDto> GetById(int id);
        Task<HeatMeterDto> AddAsync(HeatMeterRequest heatMeter);
        Task<HeatMeterDto> UpdateAsync(HeatMeterRequest heatMeter);
        Task<string> DeleteAsync(int id);
    }
}
