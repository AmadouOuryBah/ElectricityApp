using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRenter _renterService;
        private readonly IBuildingService _buildingService;

        public RoomController(IRoomService roomService, IRenter renterService, IBuildingService buildingService)
        {
            _roomService = roomService;
            _renterService = renterService;
            _buildingService = buildingService;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _roomService.GetAllAsync();

            return View(rooms);
        }

        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            ViewData["building"] = await _buildingService.GetAllAsync();
            ViewData["renter"] = await _renterService.GetAllAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
       
            ViewData["building"] = await _buildingService.GetAllAsync();
            ViewData["renter"] = await _renterService.GetAllAsync();

            return View(await _roomService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomDto room)
        {

            await _roomService.UpdateAsync(room);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Create(RoomRequest room)
        {

            await _roomService.AddAsync(room);

            return RedirectToAction("Index");
        }
    }
}
