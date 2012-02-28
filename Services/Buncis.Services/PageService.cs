using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Services.Base;
using Buncis.Core.Services;
using Buncis.Core.Repositories;
using Buncis.Data.Domain;
using System.Linq.Expressions;

namespace Buncis.Services
{
    public class PageService : BuncisBaseService, IPageService
    {
        private IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        #region IPageService Members

        public DynamicPage GetPageByFriendlyUrl(string friendlyUrl)
        {
            var pageFromDb = _pageRepository.FindBy(o => o.FriendlyUrl.Equals(friendlyUrl, StringComparison.OrdinalIgnoreCase));
            return pageFromDb;
        }

        #endregion
    }
}
