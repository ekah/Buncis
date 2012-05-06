using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.DynamicControls
{
	internal class DynamicControl
	{
		// todo: probably can chenge the key to Guid
		public string ControlKey { get; set; }
		public string RenderTag { get; set; }
	}
}
