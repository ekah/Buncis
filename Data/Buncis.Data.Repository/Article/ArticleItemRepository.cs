using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Repository.Article;
using Buncis.Data.Domain.Article;
using NHibernate;

namespace Buncis.Data.Repository.Article
{
    public class ArticleItemRepository : GenericRepository<ArticleItem>, IArticleItemRepository
    {
        public ArticleItemRepository(ISession session) :
            base(session)
        {
        }
    }
}
