using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class RenterController : Controller
    {
        private readonly IRenter _renterService;

        public RenterController(IRenter renter)
        {
            _renterService = renter;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var renters = await _renterService.GetAllAsync();

            return View(renters);
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }

        public async Task<IActionResult> Create(RenterRequest renterRequest)
        {
            await _renterService.AddAsync(renterRequest);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _renterService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RenterDto building)
        {

            await _renterService.UpdateAsync(building);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _renterService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RenterDto renter)
        {
            await _renterService.DeleteAsync(renter.Id);

            return RedirectToAction("Index");
        }

    }
}
