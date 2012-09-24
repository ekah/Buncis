using Buncis.Data.Domain.Pages;

namespace Buncis.Framework.Core.SupportClasses.Filters
{
	public interface IDynamicPageFilters : IFilter<DynamicPage>
	{
		IDynamicPageFilters Init();
		IDynamicPageFilters GetByClientId(int clientId);
		IDynamicPageFilters GetByPageId(int pageId);
		IDynamicPageFilters GetByPageUrl(string pageUrl);
		IDynamicPageFilters GetNotDeleted();
	}
}
