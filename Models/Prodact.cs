using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class Prodact
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price{ get; set; }
        public short rating{ get; set; }
        public Category Category { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }
        public string details { get; set; }
        public string Description { get; set; }
        public List<Shop> Shops { get; set; }

        public List<Trip> Trips{ get; set; }


    }
}
