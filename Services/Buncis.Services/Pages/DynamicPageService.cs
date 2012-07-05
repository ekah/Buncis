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
using Buncis.Framework.Core.Filters;

namespace Buncis.Services.Pages
{
    public class DynamicPageService : BaseService, IDynamicPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IDynamicPageFilters _dynamicPageFilters;

        public DynamicPageService(IPageRepository pageRepository,
            IDynamicPageFilters dynamicPageFilters)
        {
            _pageRepository = pageRepository;
            _dynamicPageFilters = dynamicPageFilters;
        }

        public vBuncisPage GetPageByFriendlyUrl(int clientId, string friendlyUrl)
        {
            var expression = _dynamicPageFilters.Init()
                .GetByClientId(clientId)
                .GetByFriendlyUrl(friendlyUrl)
                .Expression;
            var pageFromDb = _pageRepository.FindBy(expression);
            var viewModel = new vBuncisPage();
            viewModel.InjectFrom(pageFromDb);
            return viewModel;
        }

        public vBuncisPage GetPage(int pageId)
        {
            var expression = _dynamicPageFilters.Init()
                .GetByPageId(pageId)
                .GetNotDeleted()
                .Expression;
            var pageFromDb = _pageRepository.FindBy(expression);
            var viewModel = new vBuncisPage();
            viewModel.InjectFrom(pageFromDb);
            return viewModel;
        }

        public IEnumerable<vBuncisPage> GetPagesNotDeleted(int clientId)
        {
            var expression = _dynamicPageFilters.Init()
                .GetByClientId(clientId)
                .GetNotDeleted()
                .Expression;
            var pages = _pageRepository
                .FilterBy(expression)
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
            dPage.ClientId = clientId;

            // rule based            
            if (page.IsHomePage)
            {
                dPage.FriendlyUrl = "/";
            }

            // db operations
            if (dPage.PageId <= 0) // insert
            {
                InsertPage(dPage);
                validator.ValidatedObject.PageId = dPage.PageId; // set the pageId from inserted Id
            }
            else // update
            {
                UpdatePage(dPage);
            }

            // refetch data 
            var expression = _dynamicPageFilters.Init()
                .GetByPageId(validator.ValidatedObject.PageId)
                .GetNotDeleted()
                .Expression;
            var ping = _pageRepository.FindBy(expression);
            validator.ValidatedObject.InjectFrom(ping);

            return validator;
        }

        private void InsertPage(DynamicPage dPage)
        {
            dPage.DateCreated = DateTime.UtcNow;
            dPage.DateLastUpdated = DateTime.UtcNow;
            _pageRepository.Add(dPage);
        }

        private void UpdatePage(DynamicPage dPage)
        {
            var expression = _dynamicPageFilters.Init()
                .GetByPageId(dPage.PageId)
                .GetNotDeleted()
                .Expression;
            var fromDb = _pageRepository.FindBy(expression);
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

        public ValidationDictionary<vBuncisPage> DeletePage(int pageId)
        {
            vBuncisPage vPage;
            var expression = _dynamicPageFilters.Init()
                .GetByPageId(pageId)
                .GetNotDeleted()
                .Expression;
            var dPage = _pageRepository.FindBy(expression);
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