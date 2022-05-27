using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class DishListView
    {
        [Required]
        public long Offer_Id { get; set; }

        [Required]
        public long Dish_Id { get; set; }
    }
}
