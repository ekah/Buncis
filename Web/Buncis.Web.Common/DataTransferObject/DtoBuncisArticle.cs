using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.DataTransferObject
{
	public class DtoBuncisArticle
	{
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleTeaser { get; set; }
		public string ArticleUrl { get; set; }
		public string ArticleContent { get; set; }
		//public DateTime DateCreated { get; set; }
		public string DisplayDateCreated { get; set; }
		//public DateTime DateLastUpdated { get; set; }
		public string DisplayDateLastUpdated { get; set; }
	}
}
