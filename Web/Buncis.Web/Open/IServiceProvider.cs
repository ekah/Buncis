using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Buncis.Web.Open
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProvider" in both code and config file together.
	[ServiceContract]
	public interface IServiceProvider
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		IEnumerable<Provider> GetProvider(float langitude, float latitude);

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		IEnumerable<ProviderCategory> GetCategories();
	}
}
