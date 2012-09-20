using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Articles
{
	public interface IArticleService
	{
		IEnumerable<ViewModelArticleItem> GetAvailableArticleItems(int clientId);
		ViewModelArticleItem GetArticleItem(int newsId);
		ValidationDictionary<ViewModelArticleItem> DeleteArticleItem(int articleitemId);
		ValidationDictionary<ViewModelArticleItem> SaveArticleItem(int clientId, ViewModelArticleItem articleitem);
		IEnumerable<ViewModelArticleCategory> GetArticleCategories(int clientId);
		ValidationDictionary<ViewModelArticleCategory> InsertArticleCategory(int clientId,
		   ViewModelArticleCategory articleCategoryViewModel);
	}
}
