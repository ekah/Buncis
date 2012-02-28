using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Core.Services;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace Buncis.Web.Common.RouteHandler
{
	public class PageRouteHandler : IRouteHandler
	{
		#region IRouteHandler Members

		public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			string pageName = requestContext.RouteData.Values["PageName"] as string;

			if (string.IsNullOrEmpty(pageName))
				return RouteHandlerHelper.GetNotFoundHttpHandler();
			else
			{
				var pageService = IoC.Resolve<IPageService>();
				var pageFromDb = pageService.GetPageByFriendlyUrl(pageName);

				if (pageFromDb == null)
					return RouteHandlerHelper.GetNotFoundHttpHandler();
				else
				{
					HttpContext.Current.Items[BuncisWebConstants.HttpContextItemKeys.KEY_CURRENT_PAGE] = pageFromDb;

					return BuildManager.CreateInstanceFromVirtualPath("/Default.aspx", typeof(Page)) as Page;
				}
			}
		}

		#endregion
	}
}
