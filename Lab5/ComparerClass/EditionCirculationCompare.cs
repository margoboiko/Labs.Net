using System.Collections.Generic;
using Lab5.Models;

namespace Lab5.ComparerClass
{
    internal class EditionCompare : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            if (x.Circulation.CompareTo(y.Circulation) != 0)
            {
                return x.Circulation.CompareTo(y.Circulation);
            }

            return 0;
        }
    }
}