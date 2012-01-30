using Buncis.Data.Models;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>, IReadOnlyRepository<Category>
    {
    }
}