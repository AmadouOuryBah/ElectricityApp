
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.DataAccess.Entities;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetAllAsync();
        Task<ScheduleDto> AddAsync(ScheduleRequest scheduleRequest);
        Task<ScheduleDto> UpdateAsync(ScheduleDto scheduleDto);
        Task<string> DeleteAsync(int id);

        Task<ScheduleDto> GetByIdAsync(int id);
    }
}
