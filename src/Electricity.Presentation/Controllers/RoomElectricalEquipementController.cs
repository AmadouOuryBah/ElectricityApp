using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles="admin,user")]
    public class RoomElectricalEquipementController : Controller
    {

        private readonly IRoomElectricalEquipementService _roomElectricalEquipementService;
        private readonly IRoomService _roomService;
        private readonly IElectricityEquipement _electricityEquipementService;

        public RoomElectricalEquipementController(IRoomElectricalEquipementService roomElectricalEquipementService, IRoomService roomService, IElectricityEquipement electricityEquipementService)
        {
            _roomElectricalEquipementService = roomElectricalEquipementService;
            _roomService = roomService;
            _electricityEquipementService = electricityEquipementService;
        }
        public async Task<IActionResult> Index()
        {  

            return View(await _roomElectricalEquipementService.GetAllAsync());
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["rooms"] = await _roomService.GetAllAsync();
            ViewData["equipements"] = await _electricityEquipementService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomElectricalEquipementRequest room)
        {

            await _roomElectricalEquipementService.AddAsync(room);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            ViewData["rooms"] = await _roomService.GetAllAsync();
            ViewData["equipements"] = await _electricityEquipementService.GetAllAsync();

            return View(await _roomElectricalEquipementService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomElectricalEquipementDto room)
        {

            await _roomElectricalEquipementService.UpdateAsync(room);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _roomElectricalEquipementService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoomDto room)
        {
            await _roomElectricalEquipementService.DeleteAsync(room.Id);

            return RedirectToAction("Index");
        }


    }
}
