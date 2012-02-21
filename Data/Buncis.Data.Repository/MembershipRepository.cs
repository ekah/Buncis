using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Core.Repositories;
using Buncis.Data.Domain.Models;
using NHibernate;

namespace Buncis.Data.Repository
{
    public class MembershipRepository : GenericRepository<MembershipUser>, IMembershipRepository
    {
        public MembershipRepository(ISession session) :
            base(session)
        {
        }
    }
}
