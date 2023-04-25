
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IElectricalMeterService 
    {
        Task<List<ElectricalMeterDto>> GetAllAsync();
        Task<ElectricalMeterDto> GetById(int id);
        Task<ElectricalMeterDto> AddAsync(ElectricalMeterRequest electrical);
        Task<ElectricalMeterDto> UpdateAsync(ElectricalMeterDto electrical);
        Task DeleteAsync(int id);

        
    }
}
