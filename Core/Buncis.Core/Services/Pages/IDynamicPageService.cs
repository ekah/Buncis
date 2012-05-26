using Buncis.Data.Domain;
using Buncis.Data.Domain.Pages;
using System.Collections.Generic;

namespace Buncis.Core.Services.Pages
{
    public interface IDynamicPageService
    {
        DynamicPage GetPageByFriendlyUrl(string friendlyUrl);
        DynamicPage GetPage(int pageId);
        IList<DynamicPage> GetPagesNotDeleted();
    }
}