using Buncis.Data.Domain.Membership;
using Buncis.Framework.Core.Repository.Membership;
using NHibernate;

namespace Buncis.Data.Repository.Membership
{
    public class MembershipRoleRepository : GenericRepository<MembershipRole>, IMembershipRoleRepository
    {
        public MembershipRoleRepository(ISession session) :
            base(session)
        {
        }
    }
}
