using System;
using System.Linq;
using System.Web.Routing;

namespace Buncis.Web.Common.RouteHandler
{
    public class RouteHandlerFactory
    {
        public IRouteHandler GetRouteHandler<T>()
        {
            var typeOfT = typeof(T);
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
