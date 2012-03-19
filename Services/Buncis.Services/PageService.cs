using System;
using Buncis.Core.Repositories;
using Buncis.Core.Services;
using Buncis.Data.Domain;
using Buncis.Services.Base;

namespace Buncis.Services
{
    public class PageService : BuncisBaseService, IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        #region IPageService Members

        public DynamicPage GetPageByFriendlyUrl(string friendlyUrl)
        {
            DynamicPage pageFromDb =
                _pageRepository.FindBy(o => o.FriendlyUrl.Equals(friendlyUrl, StringComparison.OrdinalIgnoreCase));
            return pageFromDb;
        }

        #endregion
    }
}