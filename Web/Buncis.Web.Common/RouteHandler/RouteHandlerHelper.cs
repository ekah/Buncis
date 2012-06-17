using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace Buncis.Web.Common.RouteHandler
{
    public static class RouteHandlerHelper
    {
        public static IHttpHandler GetNotFoundHttpHandler()
        {
            if (HttpContext.Current.Request.Url.PathAndQuery.ToLower().Contains("/buncis/"))
            {
                return BuildManager.CreateInstanceFromVirtualPath("/bPanel/NotFound.aspx", typeof(Page)) as Page;
            }
            else
            {
                return BuildManager.CreateInstanceFromVirtualPath("/NotFound.aspx", typeof(Page)) as Page;
            }
        }
    }
}