using EquipmentMini.Contexts;
using EquipmentMini.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using EquipmentMini.Services.Interfaces;
using EquipmentMini.Contexts;
using EquipmentMini.Entities;
using EquipmentMini.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMini.Services.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly EquipmentDbContext _context;

        public EquipmentService(EquipmentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetAllAsync(string? searchString)
        {
            IQueryable<Equipment> equipment = _context.Equipment;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                equipment = equipment.Where(e =>
                    e.Name.Contains(searchString) ||
                    e.InventoryNumber.Contains(searchString) ||
                    e.Category.Name.Contains(searchString) ||
                    e.Room.Name.Contains(searchString) ||
                    e.Condition.Name.Contains(searchString));
            }

            return await EntityFrameworkQueryableExtensions.ToListAsync(equipment);
        }

        public async Task<Equipment?> GetByIdAsync(int id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        public async Task CreateAsync(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipment.Update(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
