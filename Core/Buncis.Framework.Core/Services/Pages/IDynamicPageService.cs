using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Pages
{
	public interface IDynamicPageService
	{
		ViewModelPage GetPageByPageUrl(int clientId, string pageUrl);
		ViewModelPage GetPage(int pageId);
		IEnumerable<ViewModelPage> GetAvailablePages(int clientId);
		ValidationDictionary<ViewModelPage> SavePage(int clientId, ViewModelPage page);
        ValidationDictionary<ViewModelPage> DeletePage(int pageId);
	}
}