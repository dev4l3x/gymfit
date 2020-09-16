using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Helpers
{
    using Syncfusion.DataSource.Extensions;

    public class CustomGroupComparer : IComparer<GroupResult>
    {
        public int Compare(GroupResult x, GroupResult y)
        {
            var xKey = (int) x.Key;
            var yKey = (int) y.Key;
            if (xKey > yKey)
            {
                return 1;
            }
            else if (xKey < yKey)
            {
                return -1;
            }

            return 0;
        }
    }
}
