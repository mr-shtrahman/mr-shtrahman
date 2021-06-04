using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class VisitorsAttendance
    {
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Attendance { get; set; }
        [ForeignKey("Trip")]
        public Trip Trip { get; set; }
    }
}
