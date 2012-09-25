using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.DailyBread
{
	public class DailyBreadModel
	{
		public int DailyBreadId { get; set; }
		public string DailyBreadTitle { get; set; }
		public string DailyBreadContent { get; set; }
		public string DailyBreadUrl { get; set; }
		public DateTime DatePublished { get; set; }
		public string DailyBreadBible { get; set; }
		public string DailyBreadBibleContent { get; set; }
	}
}
