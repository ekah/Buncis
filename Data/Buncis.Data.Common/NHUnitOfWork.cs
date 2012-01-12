using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure;
using NHibernate;
using System.Data;

namespace Buncis.Data.Common
{
    public class NHUnitOfWork : DisposableResource, IUnitOfWork
    {
        //private readonly ISessionFactory _sessionFactory;
        //private readonly ITransaction _transaction;

        private readonly ISession _session;
        private readonly ITransaction _transaction;

        //public NHUnitOfWork(ISessionFactory sessionFactory)
        //{
        //    _sessionFactory = sessionFactory;
        //    Session = _sessionFactory.GetCurrentSession();
        //    Session.FlushMode = FlushMode.Auto;
        //    _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        //}

        public NHUnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _session.Close();

        //    base.Dispose(disposing);
        //}

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            try
            {
                if (!_transaction.IsActive)
                {
                    throw new InvalidOperationException("No active transation");
                }
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }
    }
}
