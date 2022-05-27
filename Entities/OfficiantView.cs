using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class OfficiantView
    {
        public long Officiant_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime Hiring_Date { get; set; }

        [Required]
        [StringLength(45)]
        public string Level { get; set; }

        [StringLength(15)]
        public string Phone_Number { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
