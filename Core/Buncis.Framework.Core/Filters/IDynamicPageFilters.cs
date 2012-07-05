using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain.Pages;

namespace Buncis.Framework.Core.Filters
{
    public interface IDynamicPageFilters : IFilter<DynamicPage>
    {
        IDynamicPageFilters Init();
        IDynamicPageFilters GetByClientId(int clientId);
        IDynamicPageFilters GetByPageId(int pageId);
        IDynamicPageFilters GetByFriendlyUrl(string friendlyUrl);
        IDynamicPageFilters GetNotDeleted();
    }
}
