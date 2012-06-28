using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Framework.Core.Services.Pages
{
	public interface IDynamicPageService
	{
		vBuncisPage GetPageByFriendlyUrl(int clientId, string friendlyUrl);
		vBuncisPage GetPage(int pageId);
		IEnumerable<vBuncisPage> GetPagesNotDeleted(int clientId);
		ValidationDictionary<vBuncisPage> SavePage(int clientId, vBuncisPage page);
        ValidationDictionary<vBuncisPage> DeletePage(int pageId);
	}
}