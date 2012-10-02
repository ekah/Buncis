using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelDailyBreadItem
	{
		public int DailyBreadId { get; set; }
		public string DailyBreadTitle { get; set; }
		public string DailyBreadSummary { get; set; }
		public string DailyBreadContent { get; set; }
		public string DailyBreadUrl { get; set; }
		public DateTime DateCreated { get; set; }
		public string DisplayDateCreated
		{
			get
			{
				return DateCreated.ToBuncisLongFormatString();
			}
		}
		public DateTime DateLastUpdated { get; set; }
		public string DisplayDateLastUpdated
		{
			get
			{
				return DateLastUpdated.ToBuncisLongFormatString();
			}
		}
		public DateTime DatePublished { get; set; }
		public string DisplayDatePublished
		{
			get
			{
				return DatePublished.ToBuncisShortFormatString();
			}
		}
		public string DailyBreadBook { get; set; }
		public int DailyBreadBookChapter { get; set; }
		public int DailyBreadBookVerse1 { get; set; }
		public int DailyBreadBookVerse2 { get; set; }
		public string DailyBreadBookContent { get; set; }
		public string DailyBreadBookInfo
		{
			get
			{
				var showVerse2 = DailyBreadBookVerse2 > 0 && DailyBreadBookVerse2 != DailyBreadBookVerse1;
				return string.Format("{0} {1}:{2}{3}",
					DailyBreadBook,
					DailyBreadBookChapter,
					DailyBreadBookVerse1,
					showVerse2 ? "-" + DailyBreadBookVerse2 : string.Empty);
			}
		}
	}
}
