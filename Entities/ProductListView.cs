using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ProductListView
    {
        [Required]
        public long Id_Dish { get; set; }

        [Required]
        public long Product_Id { get; set; }

        [Required]
        public int Product_Count { get; set; }

        [Required]
        [StringLength(15)]
        public string Cooking_Type { get; set; }
    }
}
