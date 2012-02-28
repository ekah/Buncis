using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain;
using Buncis.Framework.Core.Repository;

namespace Buncis.Core.Repositories
{
    public interface IPageRepository : IRepository<DynamicPage>, IReadOnlyRepository<DynamicPage>
    {
        
    }
}
