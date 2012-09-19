using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Data.Domain.Articles
{
	public class ArticleCategory
	{
		public virtual int ArticleCategoryId { get; set; }
		public virtual string ArticleCategoryName { get; set; }
		public virtual string ArticleCategoryDescription { get; set; }
		public virtual DateTime DateCreated { get; set; }
		public virtual DateTime DateLastUpdated { get; set; }
		public virtual bool IsDeleted { get; set; }
		public virtual int ClientId { get; set; }
	}
}
