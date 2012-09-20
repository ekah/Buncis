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
		ValidationDictionary<ViewModelNewsItem> SaveNewsItem(int clientId, ViewModelNewsItem news);

		IEnumerable<ViewModelNewsItem> GetPublishedNewsItem(int clientId);
	}
}
