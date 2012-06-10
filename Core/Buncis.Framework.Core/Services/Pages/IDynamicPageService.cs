using System.Collections.Generic;
using Buncis.Data.Domain.Pages;

namespace Buncis.Framework.Services.Pages
{
    public interface IDynamicPageService
    {
        DynamicPage GetPageByFriendlyUrl(string friendlyUrl);
        DynamicPage GetPage(int pageId);
        IList<DynamicPage> GetPagesNotDeleted();
    }
}