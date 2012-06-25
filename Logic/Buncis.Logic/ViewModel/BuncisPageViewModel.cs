using System;
using System.Linq;
using Buncis.Framework.Infrastructure.Extensions;
using System.Collections.Generic;

namespace Buncis.Logic.ViewModel
{
	public class BuncisPageViewModel
	{
		public int PageId { get; set; }
		public string PageName { get; set; }
        public string PageMenuName { get; set; }
		public string PageDescription { get; set; }
		public string PageTeaser
		{
			get
			{
				var num = 6;
				var words = (PageDescription ?? string.Empty).Split(' ');
				var taken = words.Take(words.Length > num ? num : words.Length);
				var spaced = taken.Select(o => o + " ");
				return string.Format("{0}{1}", string.Concat(spaced), words.Length > num ? ".." : "");
			}
			set { }
		}
		public string PageContent { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateLastUpdated { get; set; }
		public string DisplayDateCreated
		{
			get
			{
				return DateCreated.ToLongFormatString();
			}
			set { }
		}
		public string DisplayDateLastUpdated
		{
			get
			{
				return DateLastUpdated.ToLongFormatString();
			}
			set { }
		}
		public string FriendlyUrl { get; set; }
		public bool IsHomePage
		{
			get
			{
				return FriendlyUrl.Equals("/", StringComparison.OrdinalIgnoreCase);
			}
			set { }
		}
	}
}
