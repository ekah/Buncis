using Buncis.Data.Domain.Membership;

namespace Buncis.Framework.Core.Repository.Membership
{
    public interface IMembershipUserRepository : IRepository<MembershipUser>, IReadOnlyRepository<MembershipUser>
    {
    }
}