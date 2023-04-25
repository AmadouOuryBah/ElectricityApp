
using Electricity.BusinessLogic.DTO_s;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface ISchedule
    {
        Task<List<ScheduleDto>> GetAllAsync();
        Task<ScheduleDto>> AddAsync(ScheduleRequest scheduleRequest);
        Task<ScheduleDto>> UpdateAsync(ScheduleDto scheduleRequest);
        Task<string> DeleteAsync(int id);
    }
}
