using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ProductView
    {
        public int Id_Product { get; set; }
        
        [Required]
        public string Product_Name { get; set; }
        
        [Required]
        public int Exp_Time { get; set; }
        
        [Required]
        public DateTime Arrivement_Date { get; set; }
        
        [Required]
        public double Cost { get; set; }
        
        [Required]
        public string Supplier { get; set; }
    }
}
