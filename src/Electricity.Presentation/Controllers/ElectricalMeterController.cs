using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{

    public class ElectricalMeterController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IElectricityMeterService _electricalMeterservice;
        private readonly IElectricityEquipement _electricalEquipementService;
        private readonly IRoomService _roomService;

        public ElectricalMeterController(IElectricityMeterService electricalMeterservice,
            IElectricityEquipement electricalEquipementService,
            IRoomService roomService)
        {
            _electricalMeterservice = electricalMeterservice;
            _electricalEquipementService = electricalEquipementService;
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            var electricalMeters = await _electricalMeterservice.GetAllAsync();

            return View(electricalMeters);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["equipements"] = await _electricalEquipementService.GetAllAsync();
            ViewData["rooms"] = await _roomService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ElectricalMeterRequest request)
        {
            await _electricalMeterservice.AddAsync(request);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["equipements"] = await _electricalEquipementService.GetAllAsync();
            ViewData["rooms"] = await _roomService.GetAllAsync();

            return View(await _electricalMeterservice.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ElectricityMeterDto electriclMeter)
        {

            await _electricalMeterservice.UpdateAsync(electriclMeter);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _electricalMeterservice.GetById(id)); ;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ElectricityMeterDto electricalMeterDto)
        {
            await _electricalMeterservice.DeleteAsync(electricalMeterDto.Id);

            return RedirectToAction("Index");
        }


    }
}
