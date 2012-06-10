using Buncis.Data.Domain.Membership;

namespace Buncis.Framework.Core.Repository.Membership
{
    public interface IMembershipRoleRepository : IRepository<MembershipRole>, IReadOnlyRepository<MembershipRole>
    {
    }
}
