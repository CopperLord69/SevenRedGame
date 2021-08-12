using System;
using System.Linq;
using System.Reflection;

namespace SevenRed
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumeration)
        {
            Type genericEnumType = enumeration.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumeration.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((attributes != null && attributes.Length > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)attributes.ElementAt(0)).Description;
                }
            }
            return enumeration.ToString();
        }
    }
}