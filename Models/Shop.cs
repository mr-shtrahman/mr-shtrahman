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
        private const string OpeningClosingTimeRegex = @"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";
        private const string OpeningClosingTimeErrMsg = "try in format of hh:mm";

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [Display(Name = "StreetNum")]
        public int StreetNum { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }

        [Range(0, 5)]
        public short Rating { get; set; }

        [Display(Name = "Opening Sunday Til Thursday")]
        [RegularExpression(OpeningClosingTimeRegex, ErrorMessage = OpeningClosingTimeErrMsg)]
        public string OpeningSundayTilThursday { get; set; }

        [Display(Name = "Opening Friday")]
        [RegularExpression(OpeningClosingTimeRegex, ErrorMessage = OpeningClosingTimeErrMsg)] 
        public string OpeningFriday { get; set; }

        [Display(Name = "Opening Saturday")]
        [RegularExpression(OpeningClosingTimeRegex, ErrorMessage = OpeningClosingTimeErrMsg)] 
        public string OpeningSaturday { get; set; }

        [Display(Name = "Closing Sunday Til Thursday")]
        [RegularExpression(OpeningClosingTimeRegex, ErrorMessage = OpeningClosingTimeErrMsg)]
        public string ClosingSundayTilThursday { get; set; }

        [Display(Name = "Closing Opening")]
        [RegularExpression(OpeningClosingTimeRegex, ErrorMessage = OpeningClosingTimeErrMsg)]
        public string ClosingFriday { get; set; }

        [Display(Name = "Closing Opening")]
        [RegularExpression(OpeningClosingTimeRegex, ErrorMessage = OpeningClosingTimeErrMsg)]
        public string ClosingSaturday { get; set; }

        public int ImgId { get; set; }
        public Img Img { get; set; }
        public List<Product> Products { get; set; }
        public List<Trip> Trips { get; set; }


    }
}
