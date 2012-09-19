using System;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelBuncisArticleItem
	{
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleTeaser { get; set; }
		public string ArticleUrl { get; set; }
		public string ArticleContent { get; set; }
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
		public ViewModelBuncisArticleCategory ArticleCategory { get; set; }
	}
}
