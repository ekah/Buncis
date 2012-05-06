using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Buncis.Web.Common.DynamicControls
{
    internal class DynamicControlsResolver : IDynamicControlsResolver
    {
        public void ResolveDynamicControls(Control controlToAddResult, string pageContent)
        {
            var controlRegex = new Regex(@"(\{\{::\w*::\}\})+");
            var prevStartIndex = 0;
            var prevEndIndex = 0;

            var matches = controlRegex.Matches(pageContent);
            foreach (Match match in matches)
            {
                if (!DynamicControlsContainer.DynamicControls.ContainsKey(match.Value))
                {
                    continue;
                }

                var dynamicControl = DynamicControlsContainer.DynamicControls[match.Value];
                var startIndex = match.Index;
                var endIndex = match.Length + startIndex;

                // set prev end index first
                prevEndIndex = startIndex;

                // get the control before match
                var literal = new Literal();
                literal.Text = pageContent.Substring(prevStartIndex, prevEndIndex - prevStartIndex);
                controlToAddResult.Controls.Add(literal);

                var control = controlToAddResult.Page.ParseControl(dynamicControl.RenderTag);
                controlToAddResult.Controls.Add(control);

                // set prev start index
                prevStartIndex = endIndex;
            }

            var endLiteral = new Literal();
            endLiteral.Text = pageContent.Substring(prevStartIndex, pageContent.Length - prevStartIndex);
            controlToAddResult.Controls.Add(endLiteral);

        }
    }
}
