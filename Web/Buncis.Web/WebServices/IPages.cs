using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Buncis.Web.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPages" in both code and config file together.
    [ServiceContract]
    public interface IPages
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string DoWork();
    }
}
