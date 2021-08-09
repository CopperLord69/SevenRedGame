using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SevenRed
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            if (x is null || y is null)
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
                return x.Color < y.Color ? -1 :
                       x.Color == y.Color ? 0 : 1;
            }
        }
    }
}
