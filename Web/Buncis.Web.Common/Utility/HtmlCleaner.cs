using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Buncis.Web.Common.Utility
{
	public static class HtmlCleaner
	{
		// Clean up whitespaces from generated html. Thanks to blog post made by Mads Kristensen

		private static readonly Regex REGEX_BETWEEN_TAGS = new Regex(@">s+<", RegexOptions.Compiled);
		private static readonly Regex REGEX_LINE_BREAKS = new Regex(@"ns+", RegexOptions.Compiled);

		public static void Render(HtmlTextWriter secondWriter, HtmlTextWriter originalWriter)
		{
			var html = secondWriter.InnerWriter.ToString();
			html = html.Replace("\r\n", string.Empty);
			//html = html.Replace("\t", string.Empty);
			//html = REGEX_BETWEEN_TAGS.Replace(html, "><");
			//html = REGEX_LINE_BREAKS.Replace(html, String.Empty);

			originalWriter.Write(html.Trim());
		}
	}
}
