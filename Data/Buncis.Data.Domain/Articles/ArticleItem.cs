using System;

namespace Buncis.Data.Domain.Articles
{
    public class ArticleItem
    {
        public virtual int ArticleId { get; set; }
        public virtual string ArticleTitle { get; set; }
        public virtual string ArticleTeaser { get; set; }
        public virtual string ArticleContent { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateLastUpdated { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int ClientId { get; set; }
    }
}
