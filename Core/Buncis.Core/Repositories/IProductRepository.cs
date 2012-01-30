using Buncis.Data.Models;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>, IReadOnlyRepository<Product>
    {
    }
}