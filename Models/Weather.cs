using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using mr_shtrahman.enums;

namespace mr_shtrahman.Models
{
    public class Weather
    {
        public string Id { get; set; }
        [Required]
        public double avgTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Precipitation { get; set; }
        public double humidity { get; set; }
        public  Cloudiness Cloudiness { get; set; }
        public int windSpeed { get; set; }
        [ForeignKey("Trip")]
        public Trip Trip { get; set; }
    }
}