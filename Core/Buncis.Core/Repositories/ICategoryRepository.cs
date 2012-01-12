using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Models;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>, IReadOnlyRepository<Category>
    {
    }
}
