using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mr_shtrahman.Models
{
    public class Img
    {
        public string Id { get; set; }
        [Required]
        public string Src { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("Trip")]
        [Display(Name = "Trip")]
        public int? TripId { get; set; }
        [ForeignKey("Shop")]
        [Display(Name = "Shop")]
        public int? ShopId { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }
    }
}
