using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Buncis.Web.Common.DynamicControls.Parameters.Articles;
using System.Web.Script.Serialization;

namespace Buncis.Web.Common.DynamicControls.Controls.Articles
{
	public class ArticleListControl : DynamicControl
	{
		private const string _renderTag = "<bun:ArticleList runat=\"server\" ID=\"{0}\" CategoryId=\"{1}\" />";
		private const string _renderTagNoParam = "<bun:ArticleList runat=\"server\" ID=\"{0}\" />";
		private const string _controlPath = "~/UserControls/Articles/ArticleList.ascx";

		public ArticleListControl()
		{
			ControlKey = "ArticleList";
		}

		public override Control ParseControl(Control parentControl, string jsonParam)
		{
			if (string.IsNullOrWhiteSpace(jsonParam))
			{
				var tag = string.Format(_renderTagNoParam, "ArticleList" + DateTime.UtcNow.Ticks.ToString());
				var control = parentControl.Page.ParseControl(tag);
				return control;
			}
			else
			{
				var param = (new JavaScriptSerializer()).Deserialize<ArticleListParameter>(jsonParam);
				var tag = string.Format(_renderTag, "ArticleList" + DateTime.UtcNow.Ticks.ToString(), param.CategoryId);
				var control = parentControl.Page.ParseControl(tag);
				return control;
			}
		}
	}
}
