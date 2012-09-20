using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelArticleCategory
	{
		public int ArticleCategoryId { get; set; }
		public string ArticleCategoryName { get; set; }
		public string ArticleCategoryDescription { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateLastUpdated { get; set; }
	}
}
