using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace Electricity.Presentation.Controllers
{

    public class ElectricalMeterController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IElectricalMeter _electricalMeterservice;
        private readonly IElectricalEquipement _electricalEquipementService;
        private readonly IRoom _roomService;

        public ElectricalMeterController(IElectricalMeter electricalMeterservice,
            IElectricalEquipement electricalEquipementService,
            IRoom roomService)
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

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["equipements"] = await _electricalEquipementService.GetAllAsync();
            ViewData["rooms"] = await _roomService.GetAllAsync();

            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Create(ElectricalMeterRequest request)
        {
            await _electricalMeterservice.AddAsync(request);

            return RedirectToAction("Index");
        }


    }
}
