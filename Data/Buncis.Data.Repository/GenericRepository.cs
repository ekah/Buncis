using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Buncis.Framework.Core.Repository;
using NHibernate;
using NHibernate.Linq;

namespace Buncis.Data.Repository
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		private readonly ISession _session;

		public GenericRepository(ISession session)
		{
			_session = session;
		}

		#region IRepository<T> Members

		public void Add(T entity)
		{
			_session.Save(entity);
		}

		public void Add(IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				_session.Save(item);
                _session.Refresh(item);
			}
		}

		public void Update(T entity)
		{
			_session.Update(entity);
		}

		public void Delete(T entity)
		{
			_session.Delete(entity);
		}

		public void Delete(IEnumerable<T> entities)
		{
			foreach (T entity in entities)
			{
				_session.Delete(entity);
			}
		}

		public IQueryable<T> GetAll()
		{
			return _session.Linq<T>();
		}

		public T FindBy(Expression<Func<T, bool>> expression)
		{
			try
			{
				var the = _session.Query<T>().Where(expression).Select(d => d).SingleOrDefault();
				return the;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
		{
			return _session.Query<T>().Where(expression);
		}

		#endregion
	}
}