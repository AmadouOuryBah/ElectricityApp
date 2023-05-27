using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class ElectricityConsumptionController : Controller
    {
        public readonly IElectricityConsumptionService _elecService;

        public ElectricityConsumptionController(IElectricityConsumptionService elecService)
        {
            _elecService = elecService;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            var electricitiesEnergy = await _elecService.GetAllAsync(); 
            
            return View(electricitiesEnergy);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ElectricityConsumptionRequest electricity)
        {
           await  _elecService.AddAsync(electricity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _elecService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ElectricityConsumptionDto item)
        {

            await _elecService.UpdateAsync(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _elecService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ElectricityConsumptionDto item)
        {
            await _elecService.DeleteAsync(item.Id);

            return RedirectToAction("Index");
        }
    }
}
