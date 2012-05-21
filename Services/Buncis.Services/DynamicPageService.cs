using System;
using Buncis.Core.Repositories;
using Buncis.Core.Services;
using Buncis.Data.Domain;
using Buncis.Services.Base;

namespace Buncis.Services
{
    public class DynamicPageService : CoreService, IDynamicPageService
    {
        private readonly IPageRepository _pageRepository;

        public DynamicPageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        #region IDynamicPageService Members

        public DynamicPage GetPageByFriendlyUrl(string friendlyUrl)
        {
            var pageFromDb = _pageRepository.FindBy(o => o.FriendlyUrl.Equals(friendlyUrl, StringComparison.OrdinalIgnoreCase));

            return pageFromDb;
        }

        public DynamicPage GetPage(int pageId)
        {
            var pageFromDb = _pageRepository.FindBy(o => o.PageId == pageId);

            return pageFromDb;
        }

        #endregion
    }
}