using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class ResourceController : Controller
    {
        public readonly IResourceService _resourceService;
        public readonly IBuildingService _buildingService;

        public ResourceController(IResourceService reService, IBuildingService buildingService)
        {
            _resourceService = reService;
            _buildingService = buildingService;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            var resources = await  _resourceService.GetAllAsync(); 
            
            return View(resources);
        }

        [HttpGet]
        public async Task< IActionResult> Create()
        {
            ViewData["buildings"] = await _buildingService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResourceRequest res)
        {
           await  _resourceService.AddAsync(res);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["buildings"] = await _buildingService.GetAllAsync();

            return View(await  _resourceService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResourceDto item)
        {

            await  _resourceService.UpdateAsync(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await  _resourceService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ResourceDto item)
        {
            await  _resourceService.DeleteAsync(item.Id);

            return RedirectToAction("Index");
        }
    }
}
