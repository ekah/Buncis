using Buncis.Data.Domain;

namespace Buncis.Core.Services
{
    public interface IDynamicPageService
    {
        DynamicPage GetPageByFriendlyUrl(string friendlyUrl);
        DynamicPage GetPage(int pageId);
    }
}