using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class ElectricalEquipementController : Controller
    {
        private readonly IElectricityEquipement _electricalEquipementService;

        public ElectricalEquipementController(IElectricityEquipement electricalEquipementService)
        {
            _electricalEquipementService = electricalEquipementService;
        }

        public async Task<IActionResult> Index()
        {
            var devices = await _electricalEquipementService.GetAllAsync();

            return View(devices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ElectricalEquipementRequest device)
        {
            await _electricalEquipementService.AddAsync(device);

            return RedirectToAction("Index");
        }
    }
}
