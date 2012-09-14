using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.DataTransferObject
{
	public class DtoBuncisDailyBread
	{
		public int DailyBreadId { get; set; }
		public string DailyBreadTitle { get; set; }
		public string DailyBreadSummary { get; set; }
		public string DailyBreadContent { get; set; }
		public string DailyBreadUrl { get; set; }
		public string DisplayDateCreated { get; set; }
		public string DisplayDateLastUpdated { get; set; }
		public string DailyBreadBook { get; set; }
		public int DailyBreadBookChapter { get; set; }
		public int DailyBreadBookVerse1 { get; set; }
		public int DailyBreadBookVerse2 { get; set; }
		public string DailyBreadBookContent { get; set; }
	}
}
