using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplikacja_muzyczna.Functions
{
    public class Misc
    {
        public static string DateTimeToString (DateTimeOffset Origin )
        {
            string Date = Origin.ToString();
            string[] temp1 = null;
            char separator1 = Date[2];
            temp1 = Date.Split(separator1);
            return Date = temp1[2].Substring(0, 4) + "-" + temp1[1] + "-" + temp1[0];
        }
    }
}