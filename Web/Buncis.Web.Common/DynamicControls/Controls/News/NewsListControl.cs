using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.Script.Serialization;
using Buncis.Web.Common.DynamicControls.Parameters.News;

namespace Buncis.Web.Common.DynamicControls.Controls.News
{
	public class NewsListControl : DynamicControl
	{
		private const string _renderTag = "<bun:NewsList runat=\"server\" ID=\"{0}\" CategoryId=\"{1}\" />";
		private const string _renderTagNoParam = "<bun:NewsList runat=\"server\" ID=\"{0}\" />";
		//private string _controlPath = "~/UserControls/News/NewsList.ascx";

		public NewsListControl()
		{
			ControlKey = "NewsList";
		}

		public override Control ParseControl(Control parentControl, string jsonParam)
		{
			if (string.IsNullOrWhiteSpace(jsonParam))
			{
				var tag = string.Format(_renderTagNoParam, "NewsList" + DateTime.UtcNow.Ticks.ToString());
				var control = parentControl.Page.ParseControl(tag);
				return control;
			}
			else
			{
				var param = (new JavaScriptSerializer()).Deserialize<NewsListParameter>(jsonParam);
				var tag = string.Format(_renderTag, "NewsList" + DateTime.UtcNow.Ticks.ToString(), param.CategoryId);
				var control = parentControl.Page.ParseControl(tag);
				return control;
			}
		}
	}
}
