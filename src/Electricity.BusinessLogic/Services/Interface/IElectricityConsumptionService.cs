



using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IElectricityConsumptionService
    {
        Task<List<ElectricityConsumptionDto>> GetAllAsync();
        Task<ElectricityConsumptionDto> GetById(int id);
        Task<ElectricityConsumptionDto> AddAsync(ElectricityConsumptionRequest electricity);
        Task<ElectricityConsumptionDto> UpdateAsync(ElectricityConsumptionDto electricity);
        Task<string> DeleteAsync(int id);

    }
}
