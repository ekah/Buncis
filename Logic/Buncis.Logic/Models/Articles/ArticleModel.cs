using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.Articles
{
	public class ArticleModel
	{
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleUrl { get; set; }
		public string ArticleContent { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
