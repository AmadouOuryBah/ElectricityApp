using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class HeatMeterController : Controller
    {
        public readonly IHeatMeterService _heatMeterService;

        public HeatMeterController(IHeatMeterService heatMeterService)
        {
            _heatMeterService = heatMeterService;
        }

        public async Task<IActionResult> Index()
        {   
            var heatMeters = await _heatMeterService.GetAllAsync();

            return View(heatMeters);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HeatMeterRequest request)
        {
            await _heatMeterService.AddAsync(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _heatMeterService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HeatMeterDto heatMeterDto)
        {

            await _heatMeterService.UpdateAsync(heatMeterDto);

            return RedirectToAction("Index");
        }
    }
}
