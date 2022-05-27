using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class KitchenView
    {
        public long Kitchen_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Kitchen_Name { get; set; }
    }
}
