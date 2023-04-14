
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IElectricalMeter 
    {
        Task<List<ElectricalMeterDto>> GetAllAsync();
        Task<ElectricalMeterDto> AddAsync(ElectricalMeterRequest electrical);
        Task<ElectricalMeterDto> UpdateAsync(int id, ElectricalMeterRequest electrical);
        Task<string> DeleteAsync(int id);
    }
}
