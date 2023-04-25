
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IElectricityMeterService 
    {
        Task<List<ElectricityMeterDto>> GetAllAsync();
        Task<ElectricityMeterDto> GetById(int id);
        Task<ElectricityMeterDto> AddAsync(ElectricityMeterRequest electricity);
        Task<ElectricityMeterDto> UpdateAsync(ElectricityMeterDto electricity);
        Task DeleteAsync(int id);

        
    }
}
