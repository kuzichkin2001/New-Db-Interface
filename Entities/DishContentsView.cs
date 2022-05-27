using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class DishContentsView
    {
        public long Id_Product { get; set; }

        public string Product_Name { get; set; }

        public double Cost { get; set; }

        public string Supplier { get; set; }
    }
}
