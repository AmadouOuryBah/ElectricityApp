using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
   
    public class ElectricalMeterController : Controller
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
        public RoomDto? GetRoom(int id)
        {

            return _roomService.GetById(id);
        }


        //public async Task<IActionResult> Update(int id)
        //{
        //    var electrical = await _electricalMeterservice.GetAllAsync(id);

        //    return View(electrical);
        //}
    }
}
