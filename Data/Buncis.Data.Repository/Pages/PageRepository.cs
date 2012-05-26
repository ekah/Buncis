using Buncis.Core.Repositories;
using Buncis.Data.Domain;
using NHibernate;
using Buncis.Data.Domain.Pages;
using Buncis.Core.Repositories.Pages;

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