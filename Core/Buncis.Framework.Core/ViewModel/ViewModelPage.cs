using System;
using System.Linq;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelPage
	{
		public int PageId { get; set; }
		public string PageName { get; set; }
		public string PageMenuName { get; set; }
		public string PageDescription { get; set; }
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
