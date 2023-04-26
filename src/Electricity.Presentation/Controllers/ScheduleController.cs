using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
