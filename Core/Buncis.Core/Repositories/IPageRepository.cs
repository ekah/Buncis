using Buncis.Data.Domain;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface IPageRepository : IRepository<DynamicPage>, IReadOnlyRepository<DynamicPage>
    {
    }
}