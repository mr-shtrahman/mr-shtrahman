using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Golan Heights")]
        GolanHeights,
        Galilee,
        Carmel,
        [Display(Name = "Central Israel")]
        CentralIsrael,
        Jerusalem,
        [Display(Name = "The Dead Sea")]
        TheDeadSea,
        Negev,
        Eilat
    }

    public enum TripType
    {
        Field,
        Family,
        Photography,
        Romantic,
        Urban,
        Tracks,
        Camping, 
        Circular,
        [Display(Name = "Water Entering Option")]
        WaterEnteringOption
    }

    public enum City
    {
        [Display(Name = "Tel Aviv")]
        TelAviv,
        [Display(Name = "Jerusalem")]
        Jerusalem,
        [Display(Name = "Rishon Le Tsyion")]
        RishonLeTsyion,
        [Display(Name = "Be'er Sheva")]
        BeerSheva
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Difficult,
        [Display(Name = "Suitable For Children")]
        SuitableForChildren,
        Accessible,
    }
}
