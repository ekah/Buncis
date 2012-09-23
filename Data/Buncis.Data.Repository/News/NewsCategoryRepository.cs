using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Repository.News;
using Buncis.Data.Domain.News;
using NHibernate;

namespace Buncis.Data.Repository.News
{
	public class NewsCategoryRepository : GenericRepository<NewsCategory>, INewsCategoryRepository
	{
		public NewsCategoryRepository(ISession session) :
			base(session)
		{
		}
	}
}
