using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Data.Domain.News
{
	public class NewsCategory
	{
		public virtual int NewsCategoryId { get; set; }
		public virtual string NewsCategoryName { get; set; }
		public virtual string NewsCategoryDescription { get; set; }
		public virtual DateTime DateCreated { get; set; }
		public virtual DateTime DateLastUpdated { get; set; }
		public virtual bool IsDeleted { get; set; }
		public virtual int ClientId { get; set; }
	}
}
