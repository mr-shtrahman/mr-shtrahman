using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mr_shtrahman.enums
{
    public enum Size
    {
        S,
        M,
        L,
        [Display(Name = "One Size")]
        OneSize
    }
    public enum Category
    {
        Shoes,
        Clothes,
        Camping,
        Bags,
        Gadgets,
        [Display(Name = "Israel National Trail")]
        IsraelNationalTrail
    }
    public enum Destination
    {
        Europe,
        Asia,
        [Display(Name = "Central America")]
        CentralAmerica,
        [Display(Name = "South America")]
        SouthAmerica,
        [Display(Name = "North America")]
        NorthAmerica,
        Africa,
        Australia,
    }

    public enum TripType
    {
        Field,
        Family,
        [Display(Name = "Photography Around The World")]
        PhotographyAroundTheWorld,
        Romantic,
        Urban,
        Cruise,
        Tracks,
    }

    public enum City
    {
        TelAviv,
        Jerusalem, 
        Modiin

    }

    public enum Area
    {
        South,
        North,
        TelAviv,
        Jerusalem,
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        [Display(Name = "Suitable For Children")]
        SuitableForChildren,
        Accessible,
    }
}
