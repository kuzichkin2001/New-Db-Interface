using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class RestaurantMenuView
    {
        public long Dish_Id { get; set; }

        public string Dish_Name { get; set; }

        public double Cost { get; set; }

        public string Kitchen_Name { get; set; }
    }
}
