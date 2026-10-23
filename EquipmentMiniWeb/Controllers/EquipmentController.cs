
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
    }
}
