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

		public ValidationDictionary<vBuncisPage> SavePage(vBuncisPage page)
		{
			var validator = new OnSavePageValidator(page);
			validator.Validate();

			if (!validator.IsValid)
			{
				return validator; // return immediate
			}

			var dPage = new DynamicPage();
			dPage.InjectFrom(page);

			if (page.PageId <= 0)
			{
				_pageRepository.Add(dPage);
			}
			else
			{
				_pageRepository.Update(dPage);
			}

			return validator;
		}
	}
}