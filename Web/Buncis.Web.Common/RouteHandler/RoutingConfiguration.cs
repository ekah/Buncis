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
			routes.Ignore("open/{serviceName}.svc/{*serviceActions}");

			// Register Route for Dynamic Pages
			// news route
			var newsRoute = new Route("{year}/{month}/{day}/20/{" + QueryStrings.NewsDetailId + "}/{newsTitle}",
				routeHandlerFactory.GetRouteHandler<NewsRouteHandler>());
			routes.Add(RouteNames.News, newsRoute);

			// articles route
			var articlesRoute = new Route("{year}/{month}/{day}/30/{" + QueryStrings.ArticleDetailId + "}/{articleTitle}",
				routeHandlerFactory.GetRouteHandler<ArticleRouteHandler>());
			routes.Add(RouteNames.Articles, articlesRoute);

			// daily bread route
			var dailyBreadRoute = new Route("{year}/{month}/{day}/50/{" + QueryStrings.DailyBreadDetailId + "}/{dailyBreadTitle}",
				routeHandlerFactory.GetRouteHandler<DailyBreadRouteHandler>());
			routes.Add(RouteNames.DailyBread, dailyBreadRoute);

			// page route
			var pageRoute = new Route("{*" + QueryStrings.PageName + "}",
				routeHandlerFactory.GetRouteHandler<PageRouteHandler>());
			routes.Add(RouteNames.DynamicPage, pageRoute);
		}
	}
}
