using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain.News;
using Buncis.Framework.Core.Repository.News;
using NHibernate;

namespace Buncis.Data.Repository.News
{
	public class NewsRepository : GenericRepository<NewsItem>, INewsRepository
	{
		public NewsRepository(ISession session) :
			base(session)
		{
		}
	}
}
