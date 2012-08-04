using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Data.Domain.Pages;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services.Pages;
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

        public DynamicPageService(IPageRepository pageRepository, IDynamicPageFilters dynamicPageFilters)
        {
            _pageRepository = pageRepository;
            _dynamicPageFilters = dynamicPageFilters;
        }

        public vBuncisPage GetPageByFriendlyUrl(int clientId, string friendlyUrl)
        {
            var expression = _dynamicPageFilters.Init()
                .GetByClientId(clientId)
                .GetByFriendlyUrl(friendlyUrl)
                .FilterExpression;

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
                .FilterExpression;

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
                .FilterExpression;

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
            // validation first
            var validator = new ValidationDictionary<vBuncisPage>();
            if (page == null)
            {
                validator.IsValid = false;
                validator.AddError("", "Page you're trying to save is null");
                return validator;
            }

            // rule based            
            if (page.IsHomePage)
            {

            }

            DynamicPage dPage = null;
            vBuncisPage pingedPaged = null;

            if (page.PageId <= 0)
            {
                // prepare object to save
                dPage = new DynamicPage();
                dPage.InjectFrom(page);
                dPage.ClientId = clientId;
                dPage.DateCreated = DateTime.UtcNow;
                dPage.DateLastUpdated = DateTime.UtcNow;

                _pageRepository.Add(dPage);

                pingedPaged = GetPage(dPage.PageId);
            }
            else
            {
                var gExpression = _dynamicPageFilters.Init()
                    .GetByPageId(page.PageId)
                    .GetNotDeleted()
                    .FilterExpression;

                dPage = _pageRepository.FindBy(gExpression);

                if (dPage != null)
                {
                    // excluded fields
                    var createdDate = dPage.DateCreated;
                    // update data
                    dPage.InjectFrom(dPage);
                    dPage.DateCreated = createdDate;
                    dPage.DateLastUpdated = DateTime.UtcNow;
                    dPage.IsDeleted = false;

                    _pageRepository.Update(dPage);

                    pingedPaged = GetPage(dPage.PageId);
                }
            }

            validator.IsValid = true;
            validator.RelatedObject = pingedPaged;
            return validator;
        }

        public ValidationDictionary<vBuncisPage> DeletePage(int pageId)
        {            
            var expression = _dynamicPageFilters.Init()
                .GetByPageId(pageId)
                .GetNotDeleted()
                .FilterExpression;

            var dPage = _pageRepository.FindBy(expression);
            
            var validator = new ValidationDictionary<vBuncisPage>();

            if (dPage != null)
            {
                dPage.IsDeleted = true;

                _pageRepository.Update(dPage);

                validator.IsValid = true;
            }
            else
            {
                validator.IsValid = false;
                validator.AddError("", "The Page is not found in the database");
            }

            return validator;
        }
    }
}