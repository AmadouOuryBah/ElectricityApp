using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class ConsumptionCalculationController : Controller
    {
        private readonly IBuildingService _buildingService;
        public ConsumptionCalculationController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            ViewData["buildings"] = await _buildingService.GetAllAsync();

            return View();
           
        }
    }
}
