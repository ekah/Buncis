using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.CustomEventArgs;
using Buncis.Logic.Views.Articles;
using Buncis.Framework.Core.Services.Articles;

namespace Buncis.Logic.Presenters.Articles
{
	public class ArticleListPresenter : LogicPresenter<IArticleListView>
	{
		private readonly IArticleService _articleService;

		public ArticleListPresenter(IArticleListView view, IArticleService articleService)
			: base(view)
		{
			_articleService = articleService;

			view.GetArticleList += view_GetArticleList;
		}

		void view_GetArticleList(object sender, EventArgs e)
		{
			var ae = e as ArticleListEventArgs;
			var data = ae.CategoryId > 0
				? _articleService.GetAvailableArticleItems(ae.ClientId, ae.CategoryId)
				: _articleService.GetAvailableArticleItems(ae.ClientId);
			data = data.OrderByDescending(o => o.DateCreated).ToList();

			View.Model.ArticleItems = data;
			View.BindArticleList();
		}
	}
}
