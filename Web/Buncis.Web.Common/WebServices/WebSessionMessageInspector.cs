using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using NHibernate.Burrow;
using System.Collections.Specialized;
using System.Web;

namespace Buncis.Web.Common.WebServices
{
    public class WebSessionMessageInspector : IDispatchMessageInspector
    {
        private readonly BurrowFramework _bf;

        public WebSessionMessageInspector()
        {
            _bf = new BurrowFramework();
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            _bf.InitWorkSpace(true, null, null);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            _bf.CloseWorkSpace();
        }

        private NameValueCollection GetParams(HttpRequest request)
        {
            var nameValueCollection = new NameValueCollection(request.Form);
            nameValueCollection.Add(request.ServerVariables);
            var allKeys = request.Cookies.AllKeys;
            for (int i = 0; i < (int)allKeys.Length; i++)
            {
                var str = allKeys[i];
                nameValueCollection.Add(str, request.Cookies[str].Value);
            }
            if (request.HttpMethod.ToUpper().Trim() == "GET")
            {
                nameValueCollection.Add(request.QueryString);
            }
            return nameValueCollection;
        }
    }
}
