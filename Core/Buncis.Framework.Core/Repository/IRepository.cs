using System.Collections.Generic;

namespace Buncis.Framework.Core.Repository
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