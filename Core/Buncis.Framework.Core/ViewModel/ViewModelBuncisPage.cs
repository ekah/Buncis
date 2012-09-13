using System;
using System.Linq;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelBuncisPage
	{
		public int PageId { get; set; }
		public string PageName { get; set; }
		public string PageMenuName { get; set; }
		public string PageDescription { get; set; }
		//public string PageTeaser
		//{
		//    get
		//    {
		//        var num = 5;
		//        var words = (PageDescription ?? string.Empty).Split(' ');
		//        var taken = words.Take(words.Length > num ? num : words.Length);
		//        var spaced = taken.Select(o => o + " ");
		//        return string.Format("{0}{1}", string.Concat(spaced), words.Length > num ? ".." : "");
		//    }
		//}
		public string PageContent { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateLastUpdated { get; set; }
		public string DisplayDateCreated
		{
			get
			{
				return DateCreated.ToBuncisLongFormatString();
			}
		}
		public string DisplayDateLastUpdated
		{
			get
			{
				return DateLastUpdated.ToBuncisLongFormatString();
			}
		}
		public string PageUrl { get; set; }
		public bool IsHomePage
		{
			get
			{
				return PageUrl.Equals("/", StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
