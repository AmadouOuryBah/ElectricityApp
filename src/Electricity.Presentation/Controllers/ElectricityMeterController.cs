using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{

    public class ElectricityMeterController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IElectricityMeterService _electricityMeterservice;
       

        public ElectricityMeterController(IElectricityMeterService electricalMeterservice,
            IElectricityEquipement electricalEquipementService,
            IRoomService roomService)
        {
            _electricityMeterservice = electricalMeterservice;
           
        }

        public async Task<IActionResult> Index()
        {
            var electricityMeters = await _electricityMeterservice.GetAllAsync();

            return View(electricityMeters);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ElectricityMeterRequest request)
        {
            await _electricityMeterservice.AddAsync(request);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return  View( await _electricityMeterservice.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ElectricityMeterDto electriclMeter)
        {

            await _electricityMeterservice.UpdateAsync(electriclMeter);

            return RedirectToAction("Index");
        }




    }
}
