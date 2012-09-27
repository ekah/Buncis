using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Web.Common.DynamicControls.Controls.Articles;
using Buncis.Web.Common.DynamicControls.Controls.News;
using Buncis.Web.Common.DynamicControls.Controls.DailyBread;

namespace Buncis.Web.Common.DynamicControls
{
	public static class DynamicControlsContainer
	{
		public static readonly Dictionary<string, DynamicControl> DynamicControls = new Dictionary<string, DynamicControl>();

		public static void InitializeDynamicControls()
		{
			// todo: probably can change the key to guid
			var newsListControl = new NewsListControl();
			DynamicControls.Add(newsListControl.ControlKey, newsListControl);

			var articleListControl = new ArticleListControl();
			DynamicControls.Add(articleListControl.ControlKey, articleListControl);

			var dailyBreadListControl = new DailyBreadListControl();
			DynamicControls.Add(dailyBreadListControl.ControlKey, dailyBreadListControl);
		}
	}
}
