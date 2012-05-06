using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Data.Domain
{
    public class Article
    {
        public virtual int ArticleId { get; set; }
        public virtual string ArticleTitle { get; set; }
        public virtual string ArticleTeaser { get; set; }
        public virtual string ArticleContent { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DatePublished { get; set; }
        public virtual DateTime? DateExpired { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
