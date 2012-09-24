using System;
using System.Linq;
using System.Web.Routing;
using Buncis.Framework.Core.Resources;

namespace Buncis.Web.Common.RouteHandler
{
	public class RoutingConfiguration
	{
		public void RegisterRoutes(RouteCollection routes)
		{
			var routeHandlerFactory = new RouteHandlerFactory();

			routes.Ignore("webservices/{serviceName}.svc/{*serviceActions}");

			// Register Route for Dynamic Pages
			// news route
			var newsRoute = new Route("{year}/{month}/{day}/20/{" + QueryStrings.NewsDetail_NewsId + "}/{newsTitle}",
				routeHandlerFactory.GetRouteHandler<NewsRouteHandler>());
			routes.Add(RouteNames.News, newsRoute);

			// page route
			var pageRoute = new Route("{*" + QueryStrings.PageName + "}",
				routeHandlerFactory.GetRouteHandler<PageRouteHandler>());
			routes.Add(RouteNames.DynamicPage, pageRoute);
		}
	}
}
