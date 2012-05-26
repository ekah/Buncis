using Buncis.Data.Domain;
using Buncis.Framework.Core.Repository;
using Buncis.Data.Domain.Pages;

namespace Buncis.Core.Repositories.Pages
{
    public interface IPageRepository : IRepository<DynamicPage>, IReadOnlyRepository<DynamicPage>
    {
    }
}