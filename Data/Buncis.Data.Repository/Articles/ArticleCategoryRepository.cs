using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain.Articles;
using Buncis.Framework.Core.Repository.Articles;
using NHibernate;

namespace Buncis.Data.Repository.Articles
{
	public class ArticleCategoryRepository : GenericRepository<ArticleCategory>, IArticleCategoryRepository
	{
		public ArticleCategoryRepository(ISession session)
			: base(session)
		{
		}
	}
}
