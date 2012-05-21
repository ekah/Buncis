using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Buncis.Core.Resources;
using StructureMap;

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
