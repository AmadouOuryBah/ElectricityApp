
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IConsumptionCalcultationService
    {
          Task<List<double>> FindHotWaterConsumed(FilterParameter filterParameter);
    }
}
