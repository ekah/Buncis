using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;
using Buncis.Logic.Views.Articles;
using Buncis.Framework.Core.Services.Articles;
using Buncis.Web.Common.Utility;
using Buncis.Framework.Core.Resources;
using Buncis.Web.Common.Exceptions;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses.Injector;

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
		}

		protected override void view_Initialize(object sender, EventArgs e)
		{
			var articleId = int.Parse(WebUtil.GetQueryString(QueryStrings.ArticleDetailId, "-1"));
			var articleItem = _articleService.GetArticleItem(articleId);
			if (articleItem == null)
			{
				throw new PageNotFoundException("The Page is not found in database", WebUtil.GetCurrentUrl());
			}

			View.Model.ArticleItem = new ViewModelArticleItem();
			View.Model.ArticleItem.InjectFrom<CloneInjection>(articleItem);
			View.BindViewData();
		}
	}
}
