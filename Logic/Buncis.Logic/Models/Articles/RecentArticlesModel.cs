using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.Articles
{
	public class RecentArticlesModel
	{
		public IEnumerable<ViewModelArticleItem> RecentArticles { get; set; }
	}
}
