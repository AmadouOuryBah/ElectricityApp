
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IConsumptionCalcultationService
    {
        Task<List<RenterByConsumedWater>> HotWaterConsumedByRenter(FilterParameter filterParameter);
    }
}
