using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mr_shtrahman.Models
{
    public class Img
    {
        public int Id { get; set; }
        [Required]
        public string Src { get; set; }
        [Required]
        public string Description { get; set; }
        [Column("TripId")]
        public int? TripId { get; set; }

        [ForeignKey("TripId")]
        public Trip Trip { get; set; }

        [ForeignKey("Shop")]
        [Display(Name = "Shop")]
        public int? ShopId { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }
    }
}
