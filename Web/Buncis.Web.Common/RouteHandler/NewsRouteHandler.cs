﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using Buncis.Data.Domain.News;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.Infrastructure.Utility;
using Buncis.Framework.Core.Resources;
using System.Web.UI;

namespace Buncis.Web.Common.RouteHandler
{
	public class NewsRouteHandler : BaseRouteHandler, IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var scrambledNewsId = 0;
			if (requestContext.RouteData.Values[QueryStrings.NewsDetailId] != null)
			{
				int.TryParse(requestContext.RouteData.Values[QueryStrings.NewsDetailId].ToString(), out scrambledNewsId);
			}

			var cleanNewsId = UrlUtility.Translate(scrambledNewsId);
			if (cleanNewsId <= 0)
			{
				return RouteHandlerHelper.GetNotFoundHttpHandler();
			}

			var urlEngine = IoC.Resolve<IUrlEngine<NewsItem>>();
			HttpContext.Current.RewritePath(urlEngine.ResolveUrl(HttpContext.Current.Request.Url.PathAndQuery));
			var page = BuildManager.CreateInstanceFromVirtualPath(Redirections.Page_NewsDetail, typeof(Page)) as Page;
			return page;
		}


	}
}
