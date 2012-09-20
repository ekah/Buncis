using Buncis.Data.Domain.Articles;
using Buncis.Framework.Core.Repository.Articles;
using NHibernate;

namespace Buncis.Data.Repository.Articles
{
	public class ArticleItemRepository : GenericRepository<ArticleItem>, IArticleItemRepository
	{
		public ArticleItemRepository(ISession session) :
			base(session)
		{
		}
	}
}
