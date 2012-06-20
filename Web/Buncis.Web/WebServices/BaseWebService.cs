using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using Buncis.Web.Common.Utility;

namespace Buncis.Web.WebServices
{
	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class BaseWebService
	{
		public BaseWebService()
		{
			CacheUtility.AddNoCacheToResponseHeader();
		}

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