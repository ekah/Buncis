using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain;
using Buncis.Core.Repositories;
using NHibernate;

namespace Buncis.Data.Repository
{
    public class PageRepository : GenericRepository<DynamicPage>, IPageRepository
    {
        public PageRepository(ISession session) :
            base(session)
        {
        }
    }
}
