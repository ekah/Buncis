using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.Pages
{
	public interface IDynamicPageService
	{
		ViewModelBuncisPage GetPageByFriendlyUrl(int clientId, string friendlyUrl);
		ViewModelBuncisPage GetPage(int pageId);
		IEnumerable<ViewModelBuncisPage> GetPagesNotDeleted(int clientId);
		ValidationDictionary<ViewModelBuncisPage> SavePage(int clientId, ViewModelBuncisPage page);
        ValidationDictionary<ViewModelBuncisPage> DeletePage(int pageId);
	}
}