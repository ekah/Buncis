using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using Buncis.Core.Services;
using Buncis.Data.Domain;
using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Web.Common.RouteHandler
{
    public class PageRouteHandler : IRouteHandler
    {
        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var pageName = requestContext.RouteData.Values["PageName"] as string;

            if (string.IsNullOrEmpty(pageName))
            {
                return RouteHandlerHelper.GetNotFoundHttpHandler();
            }

            var pageService = IoC.Resolve<IPageService>();
            DynamicPage pageFromDb = pageService.GetPageByFriendlyUrl(pageName);
            if (pageFromDb == null)
            {
                return RouteHandlerHelper.GetNotFoundHttpHandler();
            }

            HttpContext.Current.Items[BuncisWebConstants.HttpContextItemKeys.KEY_CURRENT_PAGE] = pageFromDb;

            return BuildManager.CreateInstanceFromVirtualPath("/Default.aspx", typeof (Page)) as Page;
        }

        #endregion
    }
}