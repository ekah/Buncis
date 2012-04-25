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
            var pageName = ResolvePageNameFromRequest(requestContext);
            int? pageId;
            if (IsValidPageRequest(pageName, out pageId))
            {
                return GetDynamicPageHandler(pageId.Value);
            }

            return RouteHandlerHelper.GetNotFoundHttpHandler();
        }

        private IHttpHandler GetDynamicPageHandler(int pageId)
        {
            var virtualPath = string.Format("{0}", Redirections.DynamicPage);
            var queryString = string.Format("?{0}={1}", QueryStrings.PageId, pageId);
            HttpContext.Current.RewritePath(string.Concat(virtualPath, queryString));
            var page = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(Page)) as Page;
            return page;
        }

        private bool IsValidPageRequest(string pageName, out int? pageId)
        {
            pageId = null;
            if (string.IsNullOrEmpty(pageName))
            {
                return false;
            }

            var pageService = IoC.Resolve<IDynamicPageService>();
            var pageFromDb = pageService.GetPageByFriendlyUrl(pageName);
            pageId = pageFromDb == null ? (int?)null : pageFromDb.PageId;
            return pageFromDb != null;
        }

        private string ResolvePageNameFromRequest(RequestContext requestContext)
        {
            var pageName = requestContext.RouteData.Values[QueryStrings.PageName] as string;
            if (requestContext.HttpContext.Request.Url.AbsolutePath == "/")
            {
                pageName = string.Empty;
            }
            pageName = string.Format("/{0}", pageName);
            return pageName;
        }

        #endregion
    }
}