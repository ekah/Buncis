using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.News
{
	public class NewsModel
	{
		public int NewsId { get; set; }
		public string NewsTitle { get; set; }
		public string NewsContent { get; set; }
		public string NewsUrl { get; set; }
		public DateTime DatePublished { get; set; }
	}
}
