using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Models;
using Buncis.Core.Repositories;
using NHibernate;

namespace Buncis.Data.Repository
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ISession session) :
            base(session)
        {
        }
    }
}
