using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Buncis.Data.Domain.Pages;
using Buncis.Framework.Core.Filters;

namespace Buncis.Services.Filters
{
    public class DynamicPageFilters : IDynamicPageFilters
    {
        private Predicate<DynamicPage> _predicate;

        public Expression<Func<DynamicPage, bool>> Expression
        {
            get
            {
                return page => _predicate(page);
            }
        }

        public DynamicPageFilters()
        {
            Init();
        }

        public IDynamicPageFilters Init()
        {
            _predicate = page => page.IsDeleted == true;
            return this;
        }

        public IDynamicPageFilters GetByClientId(int clientId)
        {
            _predicate = page => _predicate(page) && page.ClientId == clientId;
            return this;
        }

        public IDynamicPageFilters GetByPageId(int pageId)
        {
            _predicate = page => _predicate(page) && page.PageId == pageId;
            return this;
        }

        public IDynamicPageFilters GetByFriendlyUrl(string friendlyUrl)
        {
            _predicate = page => _predicate(page) && page.FriendlyUrl.Equals(friendlyUrl, StringComparison.OrdinalIgnoreCase);
            return this;
        }

        public IDynamicPageFilters GetNotDeleted()
        {
            _predicate = page => _predicate(page) && !page.IsDeleted;
            return this;
        }
    }
}
