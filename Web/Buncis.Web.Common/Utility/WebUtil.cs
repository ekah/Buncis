using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Buncis.Web.Common.Utility
{
    public static class WebUtil
    {
        public static string GetQueryString(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }

        public static string GetQueryString(string key, string defaultIfNull)
        {
            var value = GetQueryString(key);
            value = value ?? defaultIfNull;

            return value;
        }
    }
}
