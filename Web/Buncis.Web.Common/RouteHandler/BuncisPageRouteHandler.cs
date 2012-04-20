using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using Buncis.Core.Resources;
using Buncis.Core.Services;
using Buncis.Data.Domain;
using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Web.Common.RouteHandler
{
    public class BuncisPageRouteHandler : IRouteHandler
    {
        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var pageName = requestContext.RouteData.Values[QueryStrings.PageName] as string;
            if (string.IsNullOrEmpty(pageName))
            {
                if (requestContext.HttpContext.Request.Url.AbsolutePath != "/")
                {
                    return RouteHandlerHelper.GetNotFoundHttpHandler();
                }

                pageName = string.Empty;
            }

            pageName = string.Format("/{0}", pageName);
            var pageService = IoC.Resolve<IDynamicPageService>();
            var pageFromDb = pageService.GetPageByFriendlyUrl(pageName);
            if (pageFromDb == null)
            {
                return RouteHandlerHelper.GetNotFoundHttpHandler();
            }

            var virtualPath = string.Format("{0}", Redirections.DynamicPage);
            var queryString = string.Format("?{0}={1}", QueryStrings.PageId, pageFromDb.PageId);
            HttpContext.Current.RewritePath(string.Concat(virtualPath, queryString));
            var page = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(Page)) as Page;
            return page;
        }

        #endregion
    }
}