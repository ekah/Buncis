using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Web.Common.DataTransferObject;

namespace Buncis.Web.WebServices.Contracts
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDailyBread" in both code and config file together.
	[ServiceContract]
	public interface IDailyBread
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<IEnumerable<DtoBuncisDailyBread>> BPGetDailyBreadList(int clientId);

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisDailyBread> BPGetDailyBread(int clientId, int dailyBreadId);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisDailyBread> BPUpdateDailyBread(int clientId, DtoBuncisDailyBread dailyBread);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisDailyBread> BPInsertDailyBread(int clientId, DtoBuncisDailyBread dailyBread);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response BPDeleteDailyBread(int clientId, int dailyBreadId);
	}
}
