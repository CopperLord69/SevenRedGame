using System;
using System.Linq;
using System.Reflection;

namespace SevenRed
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            Type genericEnumType = @enum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(@enum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Length > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return @enum.ToString();
        }
    }
}