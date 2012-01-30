using Buncis.Core.Repositories;
using Buncis.Data.Models;
using NHibernate;

namespace Buncis.Data.Repository
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ISession session) :
            base(session)
        {
        }
    }
}