using Buncis.Logic.Views.News;
using Buncis.Framework.Core.Services.News;

namespace Buncis.Logic.Presenters.News
{
	public class RecentNewsPresenter : LogicPresenter<IRecentNewsView>
	{
		private readonly INewsService _newsService;

		public RecentNewsPresenter(IRecentNewsView view, INewsService newsService)
			: base(view)
		{
			_newsService = newsService;

			view.GetRecentNews += view_GetRecentNews;
		}

		void view_GetRecentNews(object sender, System.EventArgs e)
		{
			var recentNews = _newsService.GetRecentNews(ClientId);

			View.Model.RecentNews = recentNews;

			View.BindRecentNews();
		}
	}
}
