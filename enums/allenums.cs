using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mr_shtrahman.enums
{
    public enum Size
    {
        S,
        M,
        L,
    }
    public enum Category
    {
        shoes,
        Clothes,
        Camping,
        Bags,
        Gadgets,
        IsraelNationalTrail
    }
    public enum Destination
    {
        Europe,
        Asia,
        CentralAmerica,
        SouthAmerica,
        NorthAmerica,
        Africa,
        Australia,
    }

    public enum TripType
    {
        Field,
        Family,
        PhotographyAroundTheWorld,
        Romantic,
        Urban,
        Cruise,
        tracks,
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
        medium,
        Hard,
        SuitableForChildren,
        Accessible,
    }
}
