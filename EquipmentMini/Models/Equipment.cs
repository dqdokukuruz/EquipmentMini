using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EquipmentMini.Models.Entities
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string InventoryNumber { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Room { get; set; } = string.Empty;

        public string Condition { get; set; } = string.Empty;
    }
}
