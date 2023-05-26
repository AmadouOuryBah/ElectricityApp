using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService building)
        {
            _buildingService = building;
          
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingService.GetAllAsync();

            return View(buildings);
        }


        [HttpGet]
        //public async Task<IActionResult> Create()
        //{
          
        //}

        [HttpPost]
        public async Task<IActionResult> Create(BuildingRequest buildingRequest)
        {
            await _buildingService.AddAsync(buildingRequest);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    ViewData["electricityMeters"] = await _electricityMeterService.GetAllAsync();
        //    ViewData["heatMeters"] = await _heatMeterService.GetAllAsync();
        //    ViewData["waterMeters"] = await _waterMeterService.GetAllAsync();

        //    return View(await _buildingService.GetById(id));
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(BuildingDto building)
        {

            await _buildingService.UpdateAsync(building);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _buildingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BuildingDto buildingDto)
        {
            await _buildingService.DeleteAsync(buildingDto.Id);

             return RedirectToAction("Index");
        }

    }
}
