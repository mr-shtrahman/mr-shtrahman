using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price{ get; set; }

        [Range(0, 5)]
        public short Rating{ get; set; }
        public Category Category { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }

        [ForeignKey("Img")]
        [Display(Name = "Img")]
        public int ImgId { get; set; }
        public List<Shop> Shops { get; set; }

        public List<Trip> Trips{ get; set; }


    }
}
