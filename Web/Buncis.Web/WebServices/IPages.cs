using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Logic.DataTransferObject;

namespace Buncis.Web.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPages" in both code and config file together.
    [ServiceContract]
    public interface IPages
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<IEnumerable<oBuncisPage>> GetPages(int clientId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<oBuncisPage> GetPage(int clientId, int pageId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<oBuncisPage> UpdatePage(int clientId, oBuncisPage page);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response DeletePage(int clientId, int pageId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<oBuncisPage> InsertPage(int clientId, oBuncisPage page);
    }
}
