using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentMini.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string InventoryNumber { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Room { get; set; } = string.Empty;

        public string Condition { get; set; } = string.Empty;
    }
}
