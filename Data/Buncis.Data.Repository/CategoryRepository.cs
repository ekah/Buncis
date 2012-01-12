using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Core.Repositories;
using Buncis.Data.Models;
using NHibernate;

namespace Buncis.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ISession session)
            : base(session)
        {

        }
    }
}
