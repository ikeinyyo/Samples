using Maktub82.Samples.Attributes.Attributes;
using Maktub82.Samples.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maktub82.Samples.Attributes.Extensions
{
    public static class EnumExtensions
    {
        #region Century Example
        public static int GetStartYear(this Century enumValue)
        {
            var attribute = GetFirstOrDefaultAttribute<CenturyDataAttribute>(enumValue);
            return attribute != null ? attribute.StartYear : 0;
        }

        public static int GetEndYear(this Century enumValue)
        {
            var attribute = GetFirstOrDefaultAttribute<CenturyDataAttribute>(enumValue);
            return attribute != null ? attribute.EndYear : 0;
        }

        public static string GetCenturyName(this Century enumValue)
        {
            var attribute = GetFirstOrDefaultAttribute<CenturyDataAttribute>(enumValue);
            return attribute != null ? attribute.DisplayName : string.Empty;
        }
        #endregion

        public static string GetDisplayName(this Enum enumValue)
        {
            var attribute = GetFirstOrDefaultAttribute<DisplayNameAttribute>(enumValue);
            return attribute != null ? attribute.DisplayName : string.Empty;
        }

        public static string GenerateQuery(this Enum enumValue)
        {
            var attributes = GetAttributes<ApiValueAttribute>(enumValue);
            IEnumerable<string> values = attributes.Select(attribute => attribute.ApiValue);
            return $"{string.Join(",", values)}";
        }

        #region Private Fields
        private static T GetFirstOrDefaultAttribute<T>(Enum enumValue) where T : Attribute
        {
            var attributes = GetAttributes<T>(enumValue);
            return attributes.FirstOrDefault() as T;
        }

        private static IEnumerable<T> GetAttributes<T>(Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Cast<T>();
        }
        #endregion

    }
}
