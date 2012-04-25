using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Buncis.Web.Common.RouteHandler
{
    public class RouteHandlerFactory
    {
        public IRouteHandler GetRouteHandler<T>()
        {
            Type typeOfT = typeof(T);
            var THasIRouteHandlerInterface = typeOfT.GetInterfaces().Any(o => o.Name.Contains("IRouteHandler"));
            if (THasIRouteHandlerInterface)
            {
                var routeHandler = Activator.CreateInstance<T>();
                return (IRouteHandler)routeHandler;
            }

            return null;
        }
    }
}
