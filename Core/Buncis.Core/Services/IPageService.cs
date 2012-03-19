using Buncis.Data.Domain;

namespace Buncis.Core.Services
{
    public interface IPageService
    {
        DynamicPage GetPageByFriendlyUrl(string friendlyUrl);
    }
}