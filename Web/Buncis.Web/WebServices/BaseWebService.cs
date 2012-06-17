using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buncis.Web.WebServices
{
    public class BaseWebService
    {
        public HttpContext CurrentContext
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public HttpRequest CurrentRequest
        {
            get
            {
                return CurrentContext.Request;
            }
        }

        public HttpResponse CurrentResponse
        {
            get
            {
                return CurrentContext.Response;
            }
        }
    }
}