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
        Soldiers
    }
    public enum Destination
    {
        [Display(Name = "Golan Heights")]
        GolanHeights,
        Galilee,
        Carmel,
        Haifa,
        [Display(Name = "Tel Aviv")]
        TelAviv,
        [Display(Name = "Central Israel")]
        CentralIsrael,
        Jerusalem,
        [Display(Name = "The Dead Sea")]
        TheDeadSea,
        [Display(Name = "Northern Negev")]
        NorthNegev,
        [Display(Name = "Central Negev")]
        CentralNegev,
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
        Jerusalem,
        [Display(Name = "Rishon Le Tsyion")]
        RishonLeTsyion,
        [Display(Name = "Be'er Sheva")]
        BeerSheva,
        Eilat,
        Ariel,
        [Display(Name = "Modi'in")]
        Modiin,
        Ashdod,
        [Display(Name = "Bet Shemesh")]
        BetShemesh,
        [Display(Name = "Bat Yam")]
        BatYam,
        Herzliya,
        Holon,
        Haifa,
        Tveria,
        Carmiel, 
        [Display(Name = "Kfar Saba")]
        KfarSaba,
        Netanya,
        [Display(Name = "Petah Tikva")]
        PetahTikva,
        Rehovot,
        [Display(Name = "Ra'anana")]
        Raanana
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
