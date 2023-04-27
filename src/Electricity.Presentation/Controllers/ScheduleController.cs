﻿using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly IRoomService _roomService;

        public ScheduleController(IScheduleService scheduleService, IRoomService roomService)
        {
            _scheduleService = scheduleService;
            _roomService = roomService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _scheduleService.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["rooms"] = await _roomService.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> Create(ScheduleRequest schedule)
        {
            await _scheduleService.AddAsync(schedule);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["rooms"] = await _roomService.GetAllAsync();

            return View(await _scheduleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ScheduleDto schedule)
        {

            await _scheduleService.UpdateAsync(schedule);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _scheduleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ScheduleDto schedule)
        {
            await _scheduleService.DeleteAsync(schedule.Id);

            return RedirectToAction("Index");
        }

    }
}

