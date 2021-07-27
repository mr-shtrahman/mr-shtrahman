﻿using System;
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

        [Required]
        public City City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Street Number")]
        public int StreetNum { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }
        public short Rating { get; set; }

        [Display(Name = "Opening Time")]
        public DateTime OpeningTime { get; set; }

        public int ImgId { get; set; }
        public Img Img { get; set; }
        public List<Product> Products { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
