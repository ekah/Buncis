using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace Buncis.Web.Common.RouteHandler
{
    public static class RouteHandlerHelper
    {
        public static IHttpHandler GetNotFoundHttpHandler()
        {
            return BuildManager.CreateInstanceFromVirtualPath("/NotFound.aspx", typeof (Page)) as Page;
        }
    }
}