using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Web.Common.DataTransferObject;

namespace Buncis.Web.WebServices.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPages" in both code and config file together.
    [ServiceContract]
    public interface IPages
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<IEnumerable<DtoBuncisPage>> BPGetPages(int clientId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<DtoBuncisPage> BPGetPage(int clientId, int pageId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<DtoBuncisPage> BPUpdatePage(int clientId, DtoBuncisPage page);
		
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<DtoBuncisPage> BPInsertPage(int clientId, DtoBuncisPage page);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response BPDeletePage(int clientId, int pageId);
    }
}
