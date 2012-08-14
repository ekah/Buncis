using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Repository.DailyBread;
using Buncis.Data.Domain.DailyBread;
using NHibernate;

namespace Buncis.Data.Repository.DailyBread
{
    public class DailyBreadItemRepository : GenericRepository<DailyBreadItem>, IDailyBreadItemRepository
    {
        public DailyBreadItemRepository(ISession session) :
			base(session)
		{
		}
    }
}
