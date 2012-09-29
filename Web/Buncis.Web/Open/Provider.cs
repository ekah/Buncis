using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buncis.Web.Open
{
	public class Provider
	{
		public int ServiceProviderId { get; set; }
		public string ServiceProviderName { get; set; }
		public string ContactName { get; set; }
		public string ContactNumber { get; set; }
		public string Email { get; set; }
		public float Langitude { get; set; }
		public float Latitude { get; set; }
	}
}