using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        
        [Range(0, 5)]
        public short Rating { get; set; }
        public Destination Destination { get; set; }

        [Display(Name = "Trip Type")]
        public TripType TripType { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }

        
        [ForeignKey("Img")]
        [Display(Name = "Img")]
        public int ImgId { get; set; }

        [Display(Name = "Relevant Products")]
        public List<Product> RelevantProducts { get; set; }

        [Display(Name = "Visitors Attendance")]
        public List<VisitorsAttendance> VisitorsAttendance { get; set; }
    }
}
