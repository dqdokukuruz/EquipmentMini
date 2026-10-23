
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

        public async Task<IActionResult> Index()
        {
            var equipment = await _context.Equipment.ToListAsync();
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
                _context.Equipment.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(equipment);
        }

    }
}
