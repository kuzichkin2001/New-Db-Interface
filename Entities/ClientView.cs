using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ClientView
    {
        public long Client_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        [StringLength(255)]
        public string Phone_Number { get; set; }

        [Required]
        public long Discount_Id { get; set; }
    }
}
