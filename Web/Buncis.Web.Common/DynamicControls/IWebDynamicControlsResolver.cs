using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Buncis.Web.Common.DynamicControls
{
	public interface IWebDynamicControlsResolver
	{
		void ResolveDynamicControls(Control controlToPutResult, string pageContent);
	}
}
