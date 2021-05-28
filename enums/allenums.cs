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
        camping,
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
        romantic,
        Urban,
        Cruz,
        tracks,
    }

    public enum City
    {
        TelAviv,
        Jerusalem,
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
        Esey,
        medium,
        Hard,
        SuitableForChildren,
        Accessible,
    }

    public enum Cloudiness
    {
        Sunny,
        Bright,
        Overcast,
        Cloudy,
    }

}
