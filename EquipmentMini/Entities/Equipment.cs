
using System.ComponentModel.DataAnnotations;

namespace EquipmentMini.Entities
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

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public int ConditionId { get; set; }
        public Condition Condition { get; set; } = null!;
    }
}
