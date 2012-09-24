using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.Infrastructure.Utility;
using Buncis.Framework.Core.Resources;
using Buncis.Data.Domain.DailyBread;

namespace Buncis.Web.Common.RouteHandler
{
	public class DailyBreadRouteHandler : BaseRouteHandler, IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var scrambledDailyBreadId = 0;
			if (requestContext.RouteData.Values[QueryStrings.DailyBreadDetailId] != null)
			{
				int.TryParse(requestContext.RouteData.Values[QueryStrings.DailyBreadDetailId].ToString(), out scrambledDailyBreadId);
			}

			var cleanNewsId = UrlUtility.Translate(scrambledDailyBreadId);
			if (cleanNewsId <= 0)
			{
				return RouteHandlerHelper.GetNotFoundHttpHandler();
			}

			var urlEngine = IoC.Resolve<IUrlEngine<DailyBreadItem>>();
			HttpContext.Current.RewritePath(urlEngine.ResolveUrl(HttpContext.Current.Request.Url.PathAndQuery));
			var page = BuildManager.CreateInstanceFromVirtualPath(Redirections.Page_DailyBreadDetail, typeof(Page)) as Page;
			return page;
		}
	}
}
