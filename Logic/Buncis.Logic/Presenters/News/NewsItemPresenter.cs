using System;
using Buncis.Framework.Core.SupportClasses.Injector;
using Buncis.Framework.Core.ViewModel;
using Buncis.Logic.Views.News;
using Buncis.Web.Common.Utility;
using Buncis.Framework.Core.Resources;
using Buncis.Framework.Core.Services.News;
using Buncis.Web.Common.Exceptions;
using Omu.ValueInjecter;

namespace Buncis.Logic.Presenters.News
{
	public class NewsItemPresenter : LogicPresenter<INewsDetailView>
	{
		private readonly INewsService _newsService;

		public NewsItemPresenter(INewsDetailView view, INewsService newsService)
			: base(view)
		{
			_newsService = newsService;

			view.GetNewsDetail += view_GetNewsDetail;
		}

		void view_GetNewsDetail(object sender, EventArgs e)
		{
			var newsId = int.Parse(WebUtil.GetQueryString(QueryStrings.NewsDetailId, "-1"));
			var newsItem = _newsService.GetNewsItem(newsId);
			if (newsItem == null)
			{
				throw new PageNotFoundException("The Page is not found in database", WebUtil.GetCurrentUrl());
			}

			View.Model.DatePublished = newsItem.DatePublished;
			View.Model.NewsContent = newsItem.NewsContent;
			View.Model.NewsId = newsItem.NewsId;
			View.Model.NewsTitle = newsItem.NewsTitle;
			View.Model.NewsUrl = newsItem.NewsTeaser;

			View.BindNewsDetail();
		}
	}
}
