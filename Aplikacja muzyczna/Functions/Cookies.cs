using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplikacja_muzyczna.Functions
{
    public class Cookies
    {
        public static void Today()
        {
            RemoveCookie("DateNow");
            HttpCookie DateNow = new HttpCookie("DateNow", "")
            {
                Value = Misc.DateTimeToString(DateTimeOffset.Now)
            };
            DateNow.Expires.AddDays(1);
            HttpContext.Current.Response.SetCookie(DateNow);
        }

       public static void  CreateDay(DateTimeOffset Birth)
        {
            HttpCookie BirthDate = new HttpCookie("BirthDate", "")
            {
                Value = Misc.DateTimeToString(Birth)
            };
            BirthDate.Expires.AddDays(1);
            HttpContext.Current.Response.SetCookie(BirthDate);
        }

        public static void RemoveCookie (string name )
        {
            HttpCookie Cookie = new HttpCookie(name, "");
            HttpContext.Current.Response.Cookies.Remove(name);
            Cookie.Expires = DateTime.Now.AddDays(-10);
            Cookie.Value = null;
            HttpContext.Current.Response.SetCookie(Cookie);
        }



    }
}