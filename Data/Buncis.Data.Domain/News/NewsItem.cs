using System;

namespace Buncis.Data.Domain.News
{
	public class NewsItem
	{
		public virtual int NewsId { get; set; }
		public virtual string NewsTitle { get; set; }
		public virtual string NewsTeaser { get; set; }
		public virtual string NewsContent { get; set; }
		public virtual DateTime DatePublished { get; set; }
		public virtual DateTime DateExpired { get; set; }
		public virtual int ClientId { get; set; }
		public virtual bool IsDeleted { get; set; }
		public virtual string FriendlyUrl { get; set; }
		public virtual DateTime DateCreated { get; set; }
		public virtual DateTime DateLastUpdated { get; set; }
	}
}
