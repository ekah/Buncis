using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.CSharp;

namespace Buncis.Web.Common.Utility
{
	public static class WebUtil
	{
		public static string GetQueryString(string key)
		{
			return HttpContext.Current.Request.QueryString[key];
		}

		public static string GetQueryString(string key, string defaultIfNull)
		{
			var value = GetQueryString(key);
			value = value ?? defaultIfNull;

			return value;
		}

		public static string GetCurrentUrl()
		{
			return HttpContext.Current.Request.Url.AbsoluteUri;
		}

		//public static string GetFBFrameSrc(string url)
		//{
		//    const string format = "//www.facebook.com/plugins/like.php?href={0}&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21";
		//    var href = string.Format("{0}{1}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), url);
		//    return string.Format(format, HttpUtility.UrlEncode(href));
		//}

		public static string GetFullUrlToShare(string urlRightPart)
		{
			var href = string.Format("{0}{1}",
				HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), urlRightPart);
			//(new Random(DateTime.UtcNow.Millisecond).Next()));

			return href;
		}

		public static string GetSocialBar(string url)
		{
			var fullUrl = GetFullUrlToShare(url);
			var sb = new StringBuilder();
			sb.Append("<div class=\"socialbar\">");
			sb.AppendFormat("<span><fb:share-button type=\"button_count\" href=\"{0}\"></fb:share-button><span>", fullUrl);
			sb.AppendFormat(@"<span><a href=""https://twitter.com/share"" class=""twitter-share-button"" data-url=""{0}"">Tweet</a></span>", fullUrl);
			sb.Append("</div>");
			return sb.ToString();
		}

		public static void PutFBOpenGraphMetaTag(Page thePage, string title, string description, string rightPartUrl)
		{
			var metaContainer = GetTopLevelMasterPage(thePage).GetAllControls().AsEnumerable().FirstOrDefault(c => c.ClientID.Contains("metaFBOpenGraph")) as Literal;
			var format = @"
				<meta property=""og:title"" content=""{0}"" />
				<meta property=""og:site_name"" content=""Buncis Org"" />
				<meta property=""og:type"" content=""non_profit"" />
				<meta property=""og:url"" content=""{1}"" />
				<meta property=""og:image"" content=""http://www.buncis.org/images/custom/dailybread.jpg"" />
				<meta property=""og:description"" content=""{2}"" />
				<meta property=""fb:admins"" content=""1515047708"" />";

			metaContainer.Text = string.Format(format, title, GetFullUrlToShare(rightPartUrl), description);
		}

		public static Control GetTopLevelMasterPage(Control startingPoint)
		{
			dynamic control = null;
			if (startingPoint is Page)
			{
				control = startingPoint as Page;
			}
			if (startingPoint is MasterPage)
			{
				control = startingPoint as MasterPage;
			}

			if (control.Master != null)
			{
				return GetTopLevelMasterPage(control.Master);
			}
			return control;
		}

		public static IEnumerable<Control> GetAllControls(this Control startingPoint)
		{
			foreach (Control control in startingPoint.Controls)
			{
				yield return control;
				foreach (Control descendant in control.GetAllControls())
				{
					yield return descendant;
				}
			}
		}
	}
}
