using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootPredWeb
{
    public static class ExtensionHelpers
    {
        public static String ToOdds(this double odds)
        {
            double min1 = (1 / odds) - 1;

            if (min1 >= 1)
                return min1.ToString("0.0") + " - 1";
            else if (min1 < 1)
            {
                string o1 = (1 / min1).ToString("0.0");
                return "1 - " + o1;
            }

            throw new Exception("Can't get here");
        }
    }
}