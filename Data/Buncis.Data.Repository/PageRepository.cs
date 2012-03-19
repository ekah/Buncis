using Buncis.Core.Repositories;
using Buncis.Data.Domain;
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