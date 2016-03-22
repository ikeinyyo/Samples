﻿using System;

namespace Maktub82.Samples.Attributes.Attributes
{
    [AttributeUsage(AttributeTargets.Field)] 
    public class DisplayNameAttribute : Attribute
    {
        public readonly string DisplayName;

        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
