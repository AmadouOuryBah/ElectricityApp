

using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public  interface IWaterMeterService
    {
        Task<List<WaterMeterDto>> GetAllAsync();
        Task<WaterMeterDto> GetById(int id);
        Task<WaterMeterDto> AddAsync(WaterMeterRequest item);
        Task<WaterMeterDto> UpdateAsync(WaterMeterDto item);
        Task<string> DeleteAsync(int id);
    }
}
