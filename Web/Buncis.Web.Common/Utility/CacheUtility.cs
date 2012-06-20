using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Buncis.Web.Common.Utility
{
	public class CacheUtility
	{
		public static void AddNoCacheToResponseHeader()
		{
			HttpContext.Current.Response.ClearHeaders();
			HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
			HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
			HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			HttpContext.Current.Response.Cache.SetNoStore();
		}
	}
}
