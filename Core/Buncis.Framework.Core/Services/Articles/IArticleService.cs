using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Articles
{
	public interface IArticleService
	{
		IEnumerable<ViewModelArticleItem> GetAvailableArticleItems(int clientId);
		ViewModelArticleItem GetArticleItem(int clientId, int articleId);
		ValidationDictionary<ViewModelArticleItem> DeleteArticleItem(int clientId, int articleitemId);
		ValidationDictionary<ViewModelArticleItem> SaveArticleItem(int clientId, ViewModelArticleItem viewModelArticle);
		IEnumerable<ViewModelArticleCategory> GetArticleCategories(int clientId);
		ValidationDictionary<ViewModelArticleCategory> InsertArticleCategory(int clientId, ViewModelArticleCategory viewModelArticleCategory);
		ValidationDictionary<ViewModelArticleCategory> UpdateArticleCategory(int clientId, ViewModelArticleCategory viewModelArticleCategory);
		string GetArticleUrl(int articleId, string articleTitle);
		IEnumerable<ViewModelArticleItem> GetRecentArticles(int clientId);
		IEnumerable<ViewModelArticleItem> GetAvailableArticleItems(int clientId, int categoryId);
		ValidationDictionary<ViewModelArticleCategory> DeleteArticleCategory(int clientId, int articleCategoryId);
	}
}
