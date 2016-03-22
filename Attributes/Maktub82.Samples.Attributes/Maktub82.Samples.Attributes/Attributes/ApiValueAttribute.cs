using System;

namespace Maktub82.Samples.Attributes.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ApiValueAttribute : Attribute
    {
        public readonly string ApiValue;

        public ApiValueAttribute(string apiValue)
        {
            ApiValue = apiValue;
        }
    }
}
