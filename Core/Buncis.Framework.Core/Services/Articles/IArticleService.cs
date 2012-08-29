using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Articles
{
    public interface IArticleService
    {
        IEnumerable<ViewModelBuncisArticleItem> GetAvailableArticleItems(int clientId);
        ViewModelBuncisArticleItem GetArticleItem(int newsId);
        ValidationDictionary<ViewModelBuncisArticleItem> DeleteArticleItem(int articleitemId);
        ValidationDictionary<ViewModelBuncisArticleItem> SaveArticleItem(int clientId, ViewModelBuncisArticleItem articleitem);
    }
}
