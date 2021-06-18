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
        public double Price { get; set; }
        public short Rating { get; set; }
        public Destination Destination { get; set; }
        public TripType TripType { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public int ClosestShopsId { get; set; }
        public Shop ClosestShops { get; set; }
        public Img Img { get; set; }
        public List<Product> RelventProducts { get; set; }
        public List<VisitorsAttendance> VisitorsAttendance { get; set; }
    }
}
