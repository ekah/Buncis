using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure.Settings;
using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Web.Common.RouteHandler
{
	public class BaseRouteHandler
	{
		protected readonly ISystemSettings SystemSettings;

		public BaseRouteHandler()
		{
			SystemSettings = IoC.Resolve<ISystemSettings>();
		}
	}
}
