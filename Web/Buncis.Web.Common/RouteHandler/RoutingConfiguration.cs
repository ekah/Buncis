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

            // Register Route for Dynamic Pages
            routes.Add(RouteNames.DynamicPage,
                new Route("{*" + QueryStrings.PageName + "}",
                routeHandlerFactory.GetRouteHandler<PageRouteHandler>()));
        }
    }
}
