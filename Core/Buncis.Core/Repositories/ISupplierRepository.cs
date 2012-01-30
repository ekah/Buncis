using Buncis.Data.Models;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>, IReadOnlyRepository<Supplier>
    {
    }
}