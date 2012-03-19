using Buncis.Data.Domain;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface IMembershipRepository : IRepository<MembershipUser>, IReadOnlyRepository<MembershipUser>
    {
    }
}