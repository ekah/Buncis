using System;
using System.Linq;
using Buncis.Logic.Views.News;
using Buncis.Framework.Core.Services.News;
using Buncis.Logic.CustomEventArgs;

namespace Buncis.Logic.Presenters.News
{
	public class NewsListPresenter : LogicPresenter<INewsListView>
	{
		private readonly INewsService _newsService;

		public NewsListPresenter(INewsListView view, INewsService newsService)
			: base(view)
		{
			_newsService = newsService;

			view.GetNewsList += view_GetNewsList;
		}

		void view_GetNewsList(object sender, EventArgs e)
		{
			var ae = e as NewsListEventArgs;
			var newsData = ae.CategoryId > 0
				? _newsService.GetAvailableNewsItems(ae.ClientId, ae.CategoryId)
				: _newsService.GetPublishedNewsItem(ae.ClientId);
			newsData = newsData.OrderByDescending(o => o.DatePublished).ToList();

			View.Model.NewsItems = newsData;
			View.BindNewsList();
		}
	}
}
