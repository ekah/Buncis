using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Buncis.Web.Common.DynamicControls.Controls.DailyBread
{
	public class DailyBreadListControl : DynamicControl
	{
		private const string _renderTagNoParam = "<bun:DailyBreadList runat=\"server\" ID=\"{0}\" />";
		private const string _controlPath = "~/UserControls/DailyBread/DailyBreadList.ascx";

		public DailyBreadListControl()
		{
			ControlKey = "DailyBreadList";
		}

		public override Control ParseControl(Control parentControl, string jsonParam)
		{
			if (string.IsNullOrWhiteSpace(jsonParam))
			{
				var tag = string.Format(_renderTagNoParam, "DailyBreadList" + DateTime.UtcNow.Ticks.ToString());
				var control = parentControl.Page.ParseControl(tag);
				return control;
			}
			return null;
		}
	}
}
