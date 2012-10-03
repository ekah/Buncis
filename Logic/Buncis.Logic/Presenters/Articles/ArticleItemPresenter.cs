using System;
using Buncis.Logic.Views.Articles;
using Buncis.Framework.Core.Services.Articles;
using Buncis.Web.Common.Utility;
using Buncis.Framework.Core.Resources;
using Buncis.Web.Common.Exceptions;

namespace Buncis.Logic.Presenters.Articles
{
	public class ArticleItemPresenter : LogicPresenter<IArticleDetailView>
	{
		private readonly IArticleService _articleService;

		public ArticleItemPresenter(IArticleDetailView view,
			IArticleService articleService)
			: base(view)
		{
			_articleService = articleService;

			view.GetArticleDetail += view_GetArticleDetail;
		}

		void view_GetArticleDetail(object sender, EventArgs e)
		{
			var articleId = int.Parse(WebUtil.GetQueryString(QueryStrings.ArticleDetailId, "-1"));
			var articleItem = _articleService.GetArticleItem(ClientId, articleId);
			if (articleItem == null)
			{
				throw new PageNotFoundException("The Page is not found in database", WebUtil.GetCurrentUrl());
			}

			View.Model.ArticleUrl = articleItem.ArticleUrl;
			View.Model.ArticleId = articleItem.ArticleId;
			View.Model.ArticleTitle = articleItem.ArticleTitle;
			View.Model.ArticleContent = articleItem.ArticleContent;
			View.Model.DateCreated = articleItem.DateCreated;
			View.Model.ArticleSummary = articleItem.ArticleTeaser;

			View.BindArticleDetail();
		}
	}
}
