using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class DiscountView
    {
        public long Discount_Id { get; set; }

        [Required]
        public DateTime Start_Date { get; set; }

        [Required]
        public DateTime End_Date { get; set; }
    }
}
