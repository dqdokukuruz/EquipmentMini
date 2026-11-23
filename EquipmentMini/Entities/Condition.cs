
using System.ComponentModel.DataAnnotations;

namespace EquipmentMini.Entities
{
    public class Condition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}
