using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.Services.DailyBread;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.ViewModel;
using Buncis.Web.Common.DataTransferObject;
using Buncis.Web.WebServices.Contracts;
using Omu.ValueInjecter;

namespace Buncis.Web.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DailyBread" in code, svc and config file together.
	public class DailyBreads : BaseWebService, IDailyBreads
	{
		#region Implementation of IDailyBread

		public Response<IEnumerable<DtoBuncisDailyBread>> BPGetDailyBreads(int clientId)
		{
			var service = IoC.Resolve<IDailyBreadService>();
			var data = service.GetAvailableDailyBreadItems(clientId)
				.OrderByDescending(p => p.DateCreated)
				.ToList();

			var dto = data.Select(o => (DtoBuncisDailyBread)new DtoBuncisDailyBread().InjectFrom(o)).ToList();
			var response = new Response<IEnumerable<DtoBuncisDailyBread>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;
			return response;
		}

		public Response<DtoBuncisDailyBread> BPGetDailyBread(int clientId, int dailyBreadId)
		{
			var service = IoC.Resolve<IDailyBreadService>();
			var data = service.GetDailyBreadItem(dailyBreadId);
			var response = new Response<DtoBuncisDailyBread>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = (DtoBuncisDailyBread)new DtoBuncisDailyBread().InjectFrom(data);
			return response;
		}

		public Response<DtoBuncisDailyBread> BPUpdateDailyBread(int clientId, DtoBuncisDailyBread dailyBread)
		{
			var service = IoC.Resolve<IDailyBreadService>();
			var viewModel = (ViewModelBuncisDailyBreadItem)new ViewModelBuncisDailyBreadItem().InjectFrom(dailyBread);

			var result = service.SaveDailyBreadItem(clientId, viewModel);

			var response = new Response<DtoBuncisDailyBread>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = (DtoBuncisDailyBread)new DtoBuncisDailyBread().InjectFrom(result.RelatedObject);
			response.ResponseObject = responseObject;

			return response;
		}

		public Response<DtoBuncisDailyBread> BPInsertDailyBread(int clientId, DtoBuncisDailyBread dailyBread)
		{
			var service = IoC.Resolve<IDailyBreadService>();
			var viewModel = (ViewModelBuncisDailyBreadItem)new ViewModelBuncisDailyBreadItem().InjectFrom(dailyBread);

			var result = service.SaveDailyBreadItem(clientId, viewModel);

			var response = new Response<DtoBuncisDailyBread>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = (DtoBuncisDailyBread)new DtoBuncisDailyBread().InjectFrom(result.RelatedObject);
			response.ResponseObject = responseObject;

			return response;
		}

		public Response BPDeleteDailyBread(int clientId, int dailyBreadId)
		{
			var service = IoC.Resolve<IDailyBreadService>();
			var result = service.DeleteDailyBreadItem(dailyBreadId);
			return new Response(result.IsValid, string.Empty);
		}

		#endregion
	}
}
