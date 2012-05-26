using System;
using Buncis.Core.Repositories;
using Buncis.Core.Services;
using Buncis.Data.Domain;
using Buncis.Services.Base;
using Buncis.Core.Services.Pages;
using Buncis.Core.Repositories.Pages;
using Buncis.Data.Domain.Pages;
using System.Collections.Generic;
using System.Linq;

namespace Buncis.Services.Pages
{
    public class DynamicPageService : CoreService, IDynamicPageService
    {
        private readonly IPageRepository _pageRepository;

        public DynamicPageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

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

        public IList<DynamicPage> GetPagesNotDeleted()
        {
            var pages = _pageRepository.FilterBy(o => o.IsDeleted == false).OrderBy(o => o.PageName).ToList();
            return pages;
        }
    }
}