using System.Collections.Generic;
using System.Linq;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Web.Common.DataTransferObject;
using Omu.ValueInjecter;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Web.WebServices
{
	public class Pages : BaseWebService, IPages
	{
		public Response<IEnumerable<DtoBuncisPage>> GetPages(int clientId)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var pages = service.GetPagesNotDeleted(clientId)
				.OrderByDescending(p => p.IsHomePage)
				.ThenByDescending(o => o.DateLastUpdated)
				.ToList();
			var dto = pages.Select(o => (DtoBuncisPage)new DtoBuncisPage().InjectFrom(o)).ToList();
			var response = new Response<IEnumerable<DtoBuncisPage>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;
			return response;
		}

		public Response<DtoBuncisPage> GetPage(int clientId, int pageId)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var page = service.GetPage(pageId);
			var response = new Response<DtoBuncisPage>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = (DtoBuncisPage)new DtoBuncisPage().InjectFrom(page);
			return response;
		}

		public Response<DtoBuncisPage> UpdatePage(int clientId, DtoBuncisPage page)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var viewModel = (ViewModelBuncisPage)new ViewModelBuncisPage().InjectFrom(page);

			var result = service.SavePage(clientId, viewModel);

			var response = new Response<DtoBuncisPage>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = (DtoBuncisPage)new DtoBuncisPage().InjectFrom(result.RelatedObject);
			response.ResponseObject = responseObject;

			return response;
		}
		
		public Response<DtoBuncisPage> InsertPage(int clientId, DtoBuncisPage page)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var viewModel = (ViewModelBuncisPage)new ViewModelBuncisPage().InjectFrom(page);

			var result = service.SavePage(clientId, viewModel);

			var response = new Response<DtoBuncisPage>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = (DtoBuncisPage)new DtoBuncisPage().InjectFrom(result.RelatedObject);
			response.ResponseObject = responseObject;

			return response;
		}

		public Response DeletePage(int clientId, int pageId)
		{
			// do use clientId ?
			var service = IoC.Resolve<IDynamicPageService>();
			var result = service.DeletePage(pageId);
			return new Response(result.IsValid, string.Empty);
		}
	}
}
