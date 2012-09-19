using System.Collections.Generic;
using System.Linq;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Web.Common.DataTransferObject;
using Buncis.Web.WebServices.Contracts;
using Omu.ValueInjecter;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Web.WebServices
{
	public class Pages : BaseWebService, IPages
	{
		public Response<IEnumerable<DtoBuncisPage>> BPGetPages(int clientId)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var pages = service.GetAvailablePages(clientId)
				.OrderByDescending(p => p.IsHomePage)
				.ThenByDescending(o => o.DateLastUpdated)
				.ToList();
			var dto = pages.Select(o => new DtoBuncisPage().InjectFrom(o) as DtoBuncisPage).ToList();
			var response = new Response<IEnumerable<DtoBuncisPage>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;
			return response;
		}

		public Response<DtoBuncisPage> BPGetPage(int clientId, int pageId)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var page = service.GetPage(pageId);
			var response = new Response<DtoBuncisPage>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = new DtoBuncisPage().InjectFrom(page) as DtoBuncisPage;
			return response;
		}

		public Response<DtoBuncisPage> BPUpdatePage(int clientId, DtoBuncisPage page)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var viewModel = new ViewModelBuncisPage().InjectFrom(page) as ViewModelBuncisPage;

			var result = service.SavePage(clientId, viewModel);

			var response = new Response<DtoBuncisPage>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = new DtoBuncisPage().InjectFrom(result.RelatedObject) as DtoBuncisPage;
			response.ResponseObject = responseObject;

			return response;
		}

		public Response<DtoBuncisPage> BPInsertPage(int clientId, DtoBuncisPage page)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var viewModel = new ViewModelBuncisPage().InjectFrom(page) as ViewModelBuncisPage;

			var result = service.SavePage(clientId, viewModel);

			var response = new Response<DtoBuncisPage>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = new DtoBuncisPage().InjectFrom(result.RelatedObject) as DtoBuncisPage;
			response.ResponseObject = responseObject;

			return response;
		}

		public Response BPDeletePage(int clientId, int pageId)
		{
			// do use clientId ?
			var service = IoC.Resolve<IDynamicPageService>();
			var result = service.DeletePage(pageId);
			return new Response(result.IsValid, string.Empty);
		}
	}
}
