using EquipmentMini.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentMini.Services.Interfaces
{
    public interface IEquipmentService
    {
        public interface IEquipmentService
        {
            Task<List<Equipment>> GetAllAsync(string? searchString);

            Task<Equipment?> GetByIdAsync(int id);

            Task CreateAsync(Equipment equipment);

            Task UpdateAsync(Equipment equipment);

            Task DeleteAsync(int id);
        }

    }
}
