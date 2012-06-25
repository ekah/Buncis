using System.Collections.Generic;
using Buncis.Data.Domain.Pages;

namespace Buncis.Framework.Services.Pages
{
    public interface IDynamicPageService
    {
        DynamicPage GetPageByFriendlyUrl(int clientId, string friendlyUrl);
        DynamicPage GetPage(int pageId);
        IList<DynamicPage> GetPagesNotDeleted(int clientId);
        void SavePage(DynamicPage page);
    }
}