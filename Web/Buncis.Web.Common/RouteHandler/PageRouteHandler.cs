using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.Resources;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Web.Common.Membership;

namespace Buncis.Web.Common.RouteHandler
{
	public class PageRouteHandler : BaseRouteHandler, IRouteHandler
	{
		#region IRouteHandler Members

		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var pageName = ResolvePageNameFromRequest(requestContext);
			int? pageId;

			if (IsValidPageRequest(pageName, out pageId) && pageId.HasValue)
			{
				return GetDynamicPageHandler(pageId.Value);
			}

			return RouteHandlerHelper.GetNotFoundHttpHandler();
		}

		private IHttpHandler GetDynamicPageHandler(int pageId)
		{
			var virtualPath = string.Format("{0}", Redirections.Page_DynamicPage);
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

			try
			{
				var pageService = IoC.Resolve<IDynamicPageService>();
				var clientId = SystemSettings.ClientId;
				var pageFromDb = pageService.GetPageByFriendlyUrl(clientId, pageName);
				pageId = pageFromDb == null ? (int?)null : pageFromDb.PageId;
				return pageFromDb != null;
			}
			catch
			{
				return false;
			}
		}

		private string ResolvePageNameFromRequest(RequestContext requestContext)
		{
			var pageName = requestContext.RouteData.Values[QueryStrings.PageName] as string;
			var absolutePath = requestContext.HttpContext.Request.Url == null ? string.Empty : requestContext.HttpContext.Request.Url.AbsolutePath;
			if (absolutePath == "/")
			{
				pageName = string.Empty;
			}
			pageName = string.Format("/{0}", pageName);
			return pageName;
		}

		#endregion
	}
}