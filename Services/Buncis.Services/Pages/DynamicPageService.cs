using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Data.Domain.Pages;
using Buncis.Framework.Core.Repository.Pages;
using Buncis.Framework.Services.Pages;
using Buncis.Services.Base;

namespace Buncis.Services.Pages
{
    public class DynamicPageService : LogicService, IDynamicPageService
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