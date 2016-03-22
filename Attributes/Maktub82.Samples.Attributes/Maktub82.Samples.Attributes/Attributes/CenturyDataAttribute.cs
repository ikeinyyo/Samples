using System;

namespace Maktub82.Samples.Attributes.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CenturyDataAttribute : Attribute
    {
        private int startYear;

        public int StartYear
        {
            get { return startYear; }
            set { startYear = value; }
        }

        private int endYear;

        public int EndYear
        {
            get { return endYear; }
            set { endYear = value; }
        }

        public readonly string DisplayName;

        public CenturyDataAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
