
using EquipmentMini.Entities;
using EquipmentMini.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentMiniWeb.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var equipment = await _equipmentService.GetAllAsync(searchString);

            ViewData["CurrentFilter"] = searchString;

            return View(equipment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                await _equipmentService.CreateAsync(equipment);
                return RedirectToAction(nameof(Index));
            }

            return View(equipment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _equipmentService.GetByIdAsync(id.Value);

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _equipmentService.UpdateAsync(equipment);
                return RedirectToAction(nameof(Index));
            }

            return View(equipment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _equipmentService.GetByIdAsync(id.Value);

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _equipmentService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
