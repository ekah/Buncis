using Buncis.Core.Repositories;
using Buncis.Data.Models;
using NHibernate;

namespace Buncis.Data.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ISession session)
            : base(session)
        {
        }
    }
}