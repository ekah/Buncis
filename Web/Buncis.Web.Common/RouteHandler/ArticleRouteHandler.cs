using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using Buncis.Data.Domain.Articles;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.Resources;
using Buncis.Framework.Core.Infrastructure.Utility;

namespace Buncis.Web.Common.RouteHandler
{
	public class ArticleRouteHandler : BaseRouteHandler, IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var scrambledArticleId = 0;
			if (requestContext.RouteData.Values[QueryStrings.ArticleDetailId] != null)
			{
				int.TryParse(requestContext.RouteData.Values[QueryStrings.ArticleDetailId].ToString(), out scrambledArticleId);
			}

			var cleanNewsId = UrlUtility.Translate(scrambledArticleId);
			if (cleanNewsId <= 0)
			{
				return RouteHandlerHelper.GetNotFoundHttpHandler();
			}

			var urlEngine = IoC.Resolve<IUrlEngine<ArticleItem>>();
			HttpContext.Current.RewritePath(urlEngine.ResolveUrl(HttpContext.Current.Request.Url.PathAndQuery));
			var page = BuildManager.CreateInstanceFromVirtualPath(Redirections.Page_ArticleDetail, typeof(Page)) as Page;
			return page;
		}
	}
}
