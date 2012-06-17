using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Logic.ViewModel;

namespace Buncis.Web.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPages" in both code and config file together.
	[ServiceContract]
	public interface IPages
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<List<BuncisPageViewModel>> GetPages(int clientId);
	}
}
