using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class OfferView
    {
        public long Offer_Id { get; set; }

        [Required]
        public DateTime Offer_Time { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public long Officiant_Id { get; set; }

        [Required]
        public long Client_Id { get; set; }
    }
}
