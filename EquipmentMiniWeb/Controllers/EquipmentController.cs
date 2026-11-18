
using EquipmentMini.Contexts;
using EquipmentMini.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMiniWeb.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly EquipmentDbContext _context;

        public EquipmentController(EquipmentDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string searchString)
        {
            var equipment = _context.Equipment.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                equipment = equipment.Where(e =>
                    e.Name.Contains(searchString) ||
                    e.InventoryNumber.Contains(searchString) ||
                    e.Category.Contains(searchString) ||
                    e.Room.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await equipment.ToListAsync());
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
                _context.Equipment.Add(equipment);
                await _context.SaveChangesAsync();
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

            var equipment = await _context.Equipment.FindAsync(id);

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
                _context.Update(equipment);
                await _context.SaveChangesAsync();
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

            var equipment = await _context.Equipment
                .FirstOrDefaultAsync(e => e.Id == id);

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
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
