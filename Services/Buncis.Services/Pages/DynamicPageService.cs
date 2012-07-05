using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Data.Domain.Pages;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Services.Validator.Pages;
using Omu.ValueInjecter;
using Buncis.Framework.Core.Repository.Pages;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Services.Pages
{
    public class DynamicPageService : BaseService, IDynamicPageService
    {
        private readonly IPageRepository _pageRepository;

        public DynamicPageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public vBuncisPage GetPageByFriendlyUrl(int clientId, string friendlyUrl)
        {
            var pageFromDb = _pageRepository
                .FindBy(o => o.FriendlyUrl.Equals(friendlyUrl, StringComparison.OrdinalIgnoreCase) && o.ClientId == clientId);

            var viewModel = new vBuncisPage();
            viewModel.InjectFrom(pageFromDb);

            return viewModel;
        }

        public vBuncisPage GetPage(int pageId)
        {
            var pageFromDb = _pageRepository.FindBy(o => o.PageId == pageId && !o.IsDeleted);

            var viewModel = new vBuncisPage();
            viewModel.InjectFrom(pageFromDb);

            return viewModel;
        }

        public IEnumerable<vBuncisPage> GetPagesNotDeleted(int clientId)
        {
            var pages = _pageRepository
                .FilterBy(o => o.IsDeleted == false && o.ClientId == clientId)
                .OrderBy(o => o.PageName).ToList();

            var viewModels = pages.Select(o =>
                {
                    var viewModel = new vBuncisPage();
                    viewModel.InjectFrom(o);
                    return viewModel;
                }).ToList();

            return viewModels;
        }

        public ValidationDictionary<vBuncisPage> SavePage(int clientId, vBuncisPage page)
        {
            var validator = new OnSavePageValidator(page);
            validator.Validate();
            if (!validator.IsValid)
            {
                return validator; // return immediate
            }

            // prepare object to save
            var dPage = new DynamicPage();
            dPage.InjectFrom(page);

            // rule based
            dPage.ClientId = clientId;
            if (page.IsHomePage)
            {
                dPage.FriendlyUrl = "/";
            }

            // db operations
            if (dPage.PageId <= 0) // insert
            {
                dPage.DateCreated = DateTime.UtcNow;
                dPage.DateLastUpdated = DateTime.UtcNow;
                _pageRepository.Add(dPage);

                validator.ValidatedObject.PageId = dPage.PageId; // set the pageId from inserted Id
            }
            else // update
            {
                var fromDb = _pageRepository.FindBy(o => o.PageId == page.PageId && !o.IsDeleted);
                if (fromDb != null)
                {
                    // excluded fields
                    var createdDate = fromDb.DateCreated;

                    fromDb.InjectFrom(dPage);
                    fromDb.DateCreated = createdDate;
                    fromDb.DateLastUpdated = DateTime.UtcNow;
                    _pageRepository.Update(fromDb);
                }
            }

            // refetch data 
            var ping = _pageRepository.FindBy(o => o.PageId == validator.ValidatedObject.PageId && !o.IsDeleted);
            validator.ValidatedObject.InjectFrom(ping);            

            return validator;
        }

        public ValidationDictionary<vBuncisPage> DeletePage(int pageId)
        {
            var dPage = _pageRepository.FindBy(o => o.PageId == pageId && !o.IsDeleted);
            vBuncisPage vPage;
            if (dPage == null)
            {
                vPage = null;
            }
            else
            {
                vPage = new vBuncisPage();
                vPage.InjectFrom(dPage);
            }

            var validator = new OnDeletePageValidator(vPage);
            validator.Validate();
            if (!validator.IsValid)
            {
                return validator;
            }

            dPage.IsDeleted = true;
            _pageRepository.Update(dPage);
            return validator;
        }
    }
}