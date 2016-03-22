using Maktub82.Samples.Attributes.Attributes;

namespace Maktub82.Samples.Attributes.Enums
{
    public enum Century
    {
        [CenturyData("15th", StartYear = 1401, EndYear = 1500)]
        XV,
        [CenturyData("16th", StartYear = 1501, EndYear = 1600)]
        XVI,
        [CenturyData("17th", StartYear = 1601, EndYear = 1700)]
        XVII,
        [CenturyData("18th", StartYear = 1701, EndYear = 1800)]
        XVIII,
        [CenturyData("19th", StartYear = 1801, EndYear = 1900)]
        XIX,
        [CenturyData("20th", StartYear = 1901, EndYear = 2000)]
        XX
    }
}
