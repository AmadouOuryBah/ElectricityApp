using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IBuilding _building;

        public BuildingController(IBuilding building)
        {
            _building = building;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var buildings = await _building.GetAllAsync();

            return View(buildings);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuildingRequest buildingRequest)
        {
            await _building.AddAsync(buildingRequest);

            return RedirectToAction("Index");
        }
    }
}
