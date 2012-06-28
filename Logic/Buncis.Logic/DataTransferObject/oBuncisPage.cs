using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Logic.DataTransferObject
{
	public class oBuncisPage
	{
		public int PageId { get; set; }
		public string PageName { get; set; }
		public string PageMenuName { get; set; }
		public string PageDescription { get; set; }
		public string PageTeaser { get; set; }
		public string PageContent { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string DisplayDateCreated { get; set; }
		public string DisplayDateLastUpdated { get; set; }
		public string FriendlyUrl { get; set; }
		public bool IsHomePage { get; set; }
	}
}
