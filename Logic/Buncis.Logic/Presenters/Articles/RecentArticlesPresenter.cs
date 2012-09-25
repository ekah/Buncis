using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views.Articles;
using Buncis.Framework.Core.Services.Articles;

namespace Buncis.Logic.Presenters.Articles
{
	public class RecentArticlesPresenter : LogicPresenter<IRecentArticlesView>
	{
		private readonly IArticleService _articleService;

		public RecentArticlesPresenter(IRecentArticlesView view, IArticleService articleService)
			: base(view)
		{
			_articleService = articleService;

			view.GetRecentArticles += view_GetRecentArticles;
		}

		void view_GetRecentArticles(object sender, EventArgs e)
		{
			var recentArticles = _articleService.GetRecentArticles(ClientId);
			View.Model.RecentArticles = recentArticles;

			View.BindRecentArticles();
		}
	}
}
