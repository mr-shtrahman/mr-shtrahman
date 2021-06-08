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
        public int TripId { get; set; }
        [ForeignKey("Shop")]
        public int ShopId { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
    }
}
