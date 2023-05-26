using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles = "admin, user")]
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _electricalEquipementService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ElectricalEquipementDto item)
        {

            await _electricalEquipementService.UpdateAsync(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _electricalEquipementService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ElectricalEquipementDto item)
        {
            await _electricalEquipementService.DeleteAsync(item.Id);

            return RedirectToAction("Index");
        }

    }
}
