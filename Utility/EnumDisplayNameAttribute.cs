using System;

namespace Utility
{
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public EnumDisplayNameAttribute(string displayName)
        {
            _displayName = displayName;
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
        }
    }
}
