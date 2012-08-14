using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.News
{
	public interface INewsService
	{
		IEnumerable<vBuncisNewsItem> GetNewsItemsNotDeleted(int clientId);
		vBuncisNewsItem GetNewsItem(int newsId);
		ValidationDictionary<vBuncisNewsItem> DeleteNewsItem(int newsId);
		ValidationDictionary<vBuncisNewsItem> SaveNewsItem(int clientId, vBuncisNewsItem news);

		IEnumerable<vBuncisNewsItem> GetPublishedNewsItem(int clientId);
	}
}
