using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class RenterController : Controller
    {
        private readonly IRenter _renter;

        public RenterController(IRenter renter)
        {
            _renter = renter;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var renters = await _renter.GetAllAsync();

            return View(renters);
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }

        public async Task<IActionResult> Create(RenterRequest renterRequest)
        {
            await _renter.AddAsync(renterRequest);

            return RedirectToAction("Index");
        }
    }
}
