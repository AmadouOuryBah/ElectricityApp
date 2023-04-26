using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class WaterMeterController : Controller
    {
        private readonly IWaterMeterService _waterMeterService;
        public WaterMeterController(IWaterMeterService waterMeterService)
        { 
            _waterMeterService = waterMeterService;
        }
        public async Task<IActionResult> Index()
        {
            var waterMeters = await _waterMeterService.GetAllAsync();

            return View(waterMeters);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WaterMeterRequest request)
        {
            await _waterMeterService.AddAsync(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _waterMeterService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WaterMeterDto waterMeterDto)
        {

            await _waterMeterService.UpdateAsync(waterMeterDto);

            return RedirectToAction("Index");
        }


    }
}
