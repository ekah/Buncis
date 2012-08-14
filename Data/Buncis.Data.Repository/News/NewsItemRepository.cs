using Buncis.Data.Domain.News;
using Buncis.Framework.Core.Repository.News;
using NHibernate;

namespace Buncis.Data.Repository.News
{
	public class NewsItemRepository : GenericRepository<NewsItem>, INewsItemRepository
	{
		public NewsItemRepository(ISession session) :
			base(session)
		{
		}
	}
}
