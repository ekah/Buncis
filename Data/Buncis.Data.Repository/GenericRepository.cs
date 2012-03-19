using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Buncis.Framework.Core.Repository;
using NHibernate;
using NHibernate.Linq;

namespace Buncis.Data.Repository
{
    public class GenericRepository<T> : IRepository<T>, IReadOnlyRepository<T> where T : class
    {
        private readonly ISession _session;

        public GenericRepository(ISession session)
        {
            _session = session;
        }

        #region IRepository<T> Members

        public bool Add(T entity)
        {
            _session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _session.Linq<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return _session.Linq<T>().SingleOrDefault(expression);
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return _session.Linq<T>().Where(expression);
        }

        #endregion
    }
}