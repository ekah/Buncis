using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Framework.Core.Services.News
{
	public interface INewsService
	{
		IEnumerable<vBuncisNews> GetNewsNotDeleted(int clientId);
		vBuncisNews GetNews(int newsId);
		ValidationDictionary<vBuncisNews> DeleteNews(int newsId);
		ValidationDictionary<vBuncisNews> SaveNews(int clientId, vBuncisNews news);

		IEnumerable<vBuncisNews> GetPublishedNews(int clientId);
	}
}
