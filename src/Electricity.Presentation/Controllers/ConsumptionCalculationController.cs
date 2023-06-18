using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class ConsumptionCalculationController : Controller
    {
        private readonly IBuildingService _buildingService;
        private readonly IConsumptionCalcultationService _consumption ;
        public ConsumptionCalculationController(IBuildingService buildingService, IConsumptionCalcultationService consumption)
        {
            _buildingService = buildingService;
            _consumption = consumption;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            ViewData["buildings"] = await _buildingService.GetAllAsync();

            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Index(FilterParameter item)
        {
           var result = await _consumption.FindHotWaterConsumed(item);

            return View(result);
        }
    }
}
