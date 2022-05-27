using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class DishView
    {
        public long Dish_Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Dish_Name { get; set; }

        [Required]
        public int Kitchen_Id { get; set; }

        [Required]
        public double Cost { get; set; }
    }
}
