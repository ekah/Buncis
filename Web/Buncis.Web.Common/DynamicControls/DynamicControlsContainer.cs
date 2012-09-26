using System;
using System.Collections.Generic;
using System.Linq;

namespace Buncis.Web.Common.DynamicControls
{
	public static class DynamicControlsContainer
	{
		public static readonly Dictionary<string, DynamicControl> DynamicControls = new Dictionary<string, DynamicControl>();

		public static void InitializeDynamicControls()
		{
			// todo: probably can change the key to guid
			DynamicControls.Add(DynamicControlsLibrary.NEWS_LIST, new DynamicControl
			{
				ControlKey = "NewsList",
				RenderTag = "<bun:NewsList runat=\"server\" ID=\"ucNewsList1\" />",
				ControlPath = "~/UserControls/News/NewsList.ascx"
			});

			DynamicControls.Add(DynamicControlsLibrary.ARTICLE_LIST, new DynamicControl
			{
				ControlKey = "ArticleList",
				RenderTag = "<bun:ArticleList runat=\"server\" ID=\"ucArticleList1\" />",
				ControlPath = "~/UserControls/Articles/ArticleList.ascx"
			});

			DynamicControls.Add(DynamicControlsLibrary.DAILYBREAD_LIST, new DynamicControl
			{
				ControlKey = "DailyBreadList",
				RenderTag = "<bun:DailyBreadList runat=\"server\" ID=\"ucDailyBreadList1\" />",
				ControlPath = "~/UserControls/DailyBread/DailyBreadList.ascx"
			});
		}
	}
}
