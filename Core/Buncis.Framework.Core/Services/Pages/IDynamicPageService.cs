using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Pages
{
	public interface IDynamicPageService
	{
		ViewModelBuncisPage GetPageByPageUrl(int clientId, string pageUrl);
		ViewModelBuncisPage GetPage(int pageId);
		IEnumerable<ViewModelBuncisPage> GetAvailablePages(int clientId);
		ValidationDictionary<ViewModelBuncisPage> SavePage(int clientId, ViewModelBuncisPage page);
        ValidationDictionary<ViewModelBuncisPage> DeletePage(int pageId);
	}
}