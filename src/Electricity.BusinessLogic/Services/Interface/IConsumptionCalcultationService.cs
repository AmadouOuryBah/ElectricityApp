
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IConsumptionCalcultationService
    {
          void FindHotWaterConsumed(FilterParameter filterParameter);
    }
}
