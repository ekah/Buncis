using System;
using System.Linq;
using System.Web.UI;

namespace Buncis.Web.Common.DynamicControls
{
	public abstract class DynamicControl
	{
		// todo: probably can change the key to Guid
		public string ControlKey { get; set; }
		//public string RenderTag { get; set; }
		//public string ControlPath { get; set; }
		public abstract Control ParseControl(Control parentControl, string jsonParam);
	}
}
