using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Infrastructure.IoC;
using Omu.ValueInjecter;
using Buncis.Logic.Presenters.Pages;
using uNhAddIns.WCF;
using Buncis.Logic.DataTransferObject;
using Buncis.Framework.Core.Services.Pages;

namespace Buncis.Web.WebServices
{
	public class Pages : BaseWebService, IPages
	{
		//public Response UpdatePage(int clientId, BOBuncisPage viewModel)
		//{
		//    var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
		//    bo.Editable = viewModel;
		//    var boResponse = bo.Update();
		//    return new Response(boResponse.IsSuccess, boResponse.Message);
		//}

		//public Response DeletePage(int clientId, int pageId)
		//{
		//    var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
		//    bo.KeyToDelete = pageId;
		//    var boResponse = bo.Delete();
		//    return new Response(boResponse.IsSuccess, boResponse.Message);
		//}

		//public Response InsertPage(int clientId, BOBuncisPage viewModel)
		//{
		//    var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
		//    bo.ToInsert = viewModel;
		//    var boResponse = bo.Insert();
		//    return new Response(boResponse.IsSuccess, boResponse.Message);
		//}

		public Response<IEnumerable<oBuncisPage>> GetPages(int clientId)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var pages = service.GetPagesNotDeleted(clientId)
				.OrderByDescending(p => p.IsHomePage)
				.ThenBy(o => o.DateLastUpdated)
				.ToList();

			var dto = pages.Select(o => (oBuncisPage)new oBuncisPage().InjectFrom(o)).ToList();
			var response = new Response<IEnumerable<oBuncisPage>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;

			return response;
		}

		public Response<oBuncisPage> GetPage(int clientId, int pageId)
		{
			var service = IoC.Resolve<IDynamicPageService>();
			var page = service.GetPage(pageId);

			var response = new Response<oBuncisPage>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = (oBuncisPage)new oBuncisPage().InjectFrom(page);

			return response;
		}

		public Response UpdatePage(int clientId, oBuncisPage viewModel)
		{
			throw new NotImplementedException();
		}

		public Response DeletePage(int clientId, int pageId)
		{
			throw new NotImplementedException();
		}

		public Response InsertPage(int clientId, oBuncisPage viewModel)
		{
			throw new NotImplementedException();
		}
	}
}
