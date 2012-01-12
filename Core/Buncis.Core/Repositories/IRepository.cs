using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Core.Repositories
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        bool Add(T entity);
        bool Add(IEnumerable<T> items);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);

    }
}
