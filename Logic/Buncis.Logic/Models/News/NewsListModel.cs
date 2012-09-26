using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.News
{
	public class NewsListModel
	{
		public IEnumerable<ViewModelNewsItem> NewsItems { get; set; }
	}
}
