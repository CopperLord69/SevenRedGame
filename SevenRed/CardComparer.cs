using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SevenRed
{
    public class CardComparer : IComparer<KeyValuePair<Card, int>>, IComparer<Card>
    {
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            if(x is null || y is null)
            {
                throw new Exception("Unable to compare to null object");
            }
            if (x.Value > y.Value)
            {
                return 1;
            }
            else if (x.Value < y.Value)
            {
                return -1;
            }
            else
            {
                if (x.Color > y.Color)
                {
                    return 1;
                }
                else if (x.Color < y.Color)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Compare([AllowNull] KeyValuePair<Card, int> x, [AllowNull] KeyValuePair<Card, int> y)
        {
            if(x.Key is null || y.Key is null)
            {
                throw new Exception("Unable to compare to null object");
            }
            return Compare(x.Key, y.Key);
        }
    }
}
