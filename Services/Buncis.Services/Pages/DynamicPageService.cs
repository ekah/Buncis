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

		public ViewModelPage GetPageByPageUrl(int clientId, string pageUrl)
		{
			var expression = _dynamicPageFilters.Init()
				.GetByClientId(clientId)
				.GetByPageUrl(pageUrl)
				.FilterExpression;

			var pageFromDb = _pageRepository.FindBy(expression);

			var viewModelPage = new ViewModelPage();
			viewModelPage.InjectFrom(pageFromDb);

			return viewModelPage;
		}

		public ViewModelPage GetPage(int pageId)
		{
			var expression = _dynamicPageFilters.Init()
				.GetByPageId(pageId)
				.GetNotDeleted()
				.FilterExpression;

			var pageFromDb = _pageRepository.FindBy(expression);

			var viewModelPage = new ViewModelPage();
			viewModelPage.InjectFrom(pageFromDb);

			return viewModelPage;
		}

		public IEnumerable<ViewModelPage> GetAvailablePages(int clientId)
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
				var viewModelPage = new ViewModelPage();
				viewModelPage.InjectFrom(o);
				return viewModelPage;
			}).ToList();

			return viewModels;
		}

		public ValidationDictionary<ViewModelPage> SavePage(int clientId, ViewModelPage viewModelPage)
		{
			// validation first
			var validator = new ValidationDictionary<ViewModelPage>();
			if (viewModelPage == null)
			{
				validator.IsValid = false;
				validator.AddError("", "Page you're trying to save is null");
				return validator;
			}

			// rule based            
			if (viewModelPage.IsHomePage)
			{

			}

			DynamicPage dPage;

			if (viewModelPage.PageId <= 0)
			{
				// prepare object to save
				dPage = new DynamicPage();
				dPage.InjectFrom(viewModelPage);
				dPage.ClientId = clientId;
				dPage.DateCreated = DateTime.UtcNow;
				dPage.DateLastUpdated = DateTime.UtcNow;

				_pageRepository.Add(dPage);
			}
			else
			{
				var gExpression = _dynamicPageFilters.Init()
					.GetByPageId(viewModelPage.PageId)
					.GetNotDeleted()
					.FilterExpression;

				dPage = _pageRepository.FindBy(gExpression);

				if (dPage != null)
				{
					// excluded fields
					var createdDate = dPage.DateCreated;
					// update data
					dPage.InjectFrom(viewModelPage);
					dPage.DateCreated = createdDate;
					dPage.DateLastUpdated = DateTime.UtcNow;
					dPage.IsDeleted = false;

					_pageRepository.Update(dPage);
				}
			}

			ViewModelPage pingedPaged = GetPage(dPage.PageId);
			validator.IsValid = true;
			validator.RelatedObject = pingedPaged;
			return validator;
		}

		public ValidationDictionary<ViewModelPage> DeletePage(int pageId)
		{
			var expression = _dynamicPageFilters.Init()
				.GetByPageId(pageId)
				.GetNotDeleted()
				.FilterExpression;

			var dPage = _pageRepository.FindBy(expression);

			var validator = new ValidationDictionary<ViewModelPage>();

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