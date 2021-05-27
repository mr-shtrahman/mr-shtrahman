using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class Shop
    {
        public string Id { get; set; }

        [Required] 
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public short rating { get; set; }
        public string Location { get; set; }
        public DateTime OpeningTime { get; set; }
        public Area Area { get; set; }
        public City City { get; set; }
        public List<Prodact> Prodacts { get; set; }
        public List<Trip> Trips { get; set; }


    }
}
