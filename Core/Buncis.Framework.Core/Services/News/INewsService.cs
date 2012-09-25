using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.News
{
	public interface INewsService
	{
		IEnumerable<ViewModelNewsItem> GetAvailableNewsItems(int clientId);
		ViewModelNewsItem GetNewsItem(int newsId);
		ValidationDictionary<ViewModelNewsItem> DeleteNewsItem(int newsId);
		ValidationDictionary<ViewModelNewsItem> SaveNewsItem(int clientId, ViewModelNewsItem viewModelNews);
		IEnumerable<ViewModelNewsItem> GetPublishedNewsItem(int clientId);
		IEnumerable<ViewModelNewsCategory> GetNewsCategories(int clientId);
		ValidationDictionary<ViewModelNewsCategory> InsertNewsCategory(int clientId, ViewModelNewsCategory viewModelNewsCategory);
		string GetNewsUrl(int newsId, string newsTitle);

		/// <summary>
		/// Get Recent News, just get top 10 news
		/// </summary>
		/// <returns></returns>
		IEnumerable<ViewModelNewsItem> GetRecentNews(int clientId);
	}
}
