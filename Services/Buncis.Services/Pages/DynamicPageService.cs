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

        public DynamicPage GetPageByFriendlyUrl(int clientId, string friendlyUrl)
        {
            var pageFromDb = _pageRepository
                .FindBy(o => o.FriendlyUrl.Equals(friendlyUrl, StringComparison.OrdinalIgnoreCase) && o.ClientId == clientId);

            return pageFromDb;
        }

        public DynamicPage GetPage(int pageId)
        {
            var pageFromDb = _pageRepository.FindBy(o => o.PageId == pageId && !o.IsDeleted);

            return pageFromDb;
        }

        public IList<DynamicPage> GetPagesNotDeleted(int clientId)
        {
            var pages = _pageRepository
                .FilterBy(o => o.IsDeleted == false && o.ClientId == clientId)
                .OrderBy(o => o.PageName).ToList();

            return pages;
        }

        public void SavePage(DynamicPage page)
        {
            if (page.PageId <= 0)
            {
                _pageRepository.Add(page);
            }
            else
            {
                _pageRepository.Update(page);
            }
        }
    }
}