using System.Collections.Generic;

namespace Buncis.Framework.Core.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        void Add(T entity);

        void Add(IEnumerable<T> items);

        void Update(T entity);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}