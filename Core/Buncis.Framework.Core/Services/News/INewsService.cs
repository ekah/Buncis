using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.News
{
	public interface INewsService
	{
		IEnumerable<ViewModelBuncisNewsItem> GetAvailableNewsItems(int clientId);
		ViewModelBuncisNewsItem GetNewsItem(int newsId);
		ValidationDictionary<ViewModelBuncisNewsItem> DeleteNewsItem(int newsId);
		ValidationDictionary<ViewModelBuncisNewsItem> SaveNewsItem(int clientId, ViewModelBuncisNewsItem news);

		IEnumerable<ViewModelBuncisNewsItem> GetPublishedNewsItem(int clientId);
	}
}
