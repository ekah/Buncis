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
			var pageRoute = new Route("{*" + QueryStrings.PageName + "}", routeHandlerFactory.GetRouteHandler<PageRouteHandler>());
			routes.Add(RouteNames.DynamicPage, pageRoute);
		}
	}
}
