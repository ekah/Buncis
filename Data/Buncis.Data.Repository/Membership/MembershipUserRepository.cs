using Buncis.Data.Domain.Membership;
using Buncis.Framework.Core.Repository.Membership;
using NHibernate;

namespace Buncis.Data.Repository.Membership
{
    public class MembershipUserRepository : GenericRepository<MembershipUser>, IMembershipUserRepository
    {
        public MembershipUserRepository(ISession session) :
            base(session)
        {
        }
    }
}
