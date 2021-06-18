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
        OneSize
    }
    public enum Category
    {
        Shoes,
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
        SuitableForChildren,
        Accessible,
    }
}
