using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using Buncis.Framework.Core.Infrastructure.Utility;
using Buncis.Framework.Core.Resources;
using System.Web.UI;

namespace Buncis.Web.Common.RouteHandler
{
	public class NewsRouteHandler : BaseRouteHandler, IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var scrambledNewsId = 0;
			if (requestContext.RouteData.Values[QueryStrings.NewsDetail_NewsId] != null)
			{
				int.TryParse(requestContext.RouteData.Values[QueryStrings.NewsDetail_NewsId].ToString(), out scrambledNewsId);
			}

			var cleanNewsId = UrlUtility.Translate(scrambledNewsId);
			if (cleanNewsId <= 0)
			{
				return RouteHandlerHelper.GetNotFoundHttpHandler();
			}

			var virtualPath = string.Format("{0}", Redirections.Page_NewsDetail);
			var queryString = string.Format("?{0}={1}", QueryStrings.NewsDetail_NewsId, cleanNewsId);
			HttpContext.Current.RewritePath(string.Concat(virtualPath, queryString));
			var page = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(Page)) as Page;
			return page;
		}


	}
}
