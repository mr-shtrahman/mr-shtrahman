using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class Trip
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public short rating { get; set; }
        public Destination Destination { get; set; }
        public TripType TripType { get; set; }
        public string Location { get; set; }
        public string details { get; set; }
        public Shop ClosestShops { get; set; }
        public List<Prodact> RelventProdacts{ get; set; }


    }
}
