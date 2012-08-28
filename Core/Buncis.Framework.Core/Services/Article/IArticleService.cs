using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Article
{
    public interface IArticleService
    {
        IEnumerable<ViewModelArticleItem> GetArticleItemsNotDeleted(int clientId);
        ViewModelArticleItem GetArticleItem(int newsId);
        ValidationDictionary<ViewModelArticleItem> DeleteArticleItem(int articleitemId);
        ValidationDictionary<ViewModelArticleItem> SaveArticleItem(int clientId, ViewModelArticleItem articleitem);
    }
}
