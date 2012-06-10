using Buncis.Data.Domain.Pages;
using Buncis.Framework.Core.Repository.Pages;
using NHibernate;

namespace Buncis.Data.Repository.Pages
{
    public class PageRepository : GenericRepository<DynamicPage>, IPageRepository
    {
        public PageRepository(ISession session) :
            base(session)
        {
        }
    }
}