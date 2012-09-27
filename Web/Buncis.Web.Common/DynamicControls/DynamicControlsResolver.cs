using System;
using System.Linq;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Buncis.Web.Common.DynamicControls
{
	internal class DynamicControlsResolver : IDynamicControlsResolver
	{
		public void ResolveDynamicControls(Control controlToAddResult, string pageContent)
		{
			var controlRegex = new Regex(@"(\{\{::\w*(\{.*\})?::\}\})+");
			var prevStartIndex = 0;

			var matches = controlRegex.Matches(pageContent);
			foreach (Match match in matches)
			{
				var matchValue = match.Value.Replace("{{::", "").Replace("::}}", "");
				var matchParam = string.Empty;

				// check if the control string has json param in it
				if (matchValue.Contains("{") && matchValue.Contains("}"))
				{
					// ORDERLY
					var si = matchValue.IndexOf("{");
					var ei = matchValue.IndexOf("}");
					matchParam = matchValue.Substring(si, (ei - si) + 1);
					matchValue = matchValue.Substring(0, matchValue.IndexOf("{"));
				}

				if (!DynamicControlsContainer.DynamicControls.ContainsKey(matchValue))
				{
					continue;
				}

				// get the control before match, put it into a literal control
				var literal = new Literal();
				literal.Text = pageContent.Substring(prevStartIndex, match.Index - prevStartIndex);
				controlToAddResult.Controls.Add(literal);

				// get dynamic control based on control key from the container
				var dynamicControl = DynamicControlsContainer.DynamicControls[matchValue];

				// now, get the dynamic control actual control object, add to controls collection
				//var control = controlToAddResult.Page.ParseControl(dynamicControl.RenderTag);
				var control = dynamicControl.ParseControl(controlToAddResult, matchParam);
				controlToAddResult.Controls.Add(control);

				// set prev start index
				var startIndex = match.Index;
				var endIndex = match.Length + startIndex;
				prevStartIndex = endIndex;
			}

			var endLiteral = new Literal();
			endLiteral.Text = pageContent.Substring(prevStartIndex, pageContent.Length - prevStartIndex);
			controlToAddResult.Controls.Add(endLiteral);

		}
	}
}
