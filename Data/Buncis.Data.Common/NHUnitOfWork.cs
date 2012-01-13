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
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHUnitOfWork(ISession session)
        {
            _session = session;
        }

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

        /// <summary>
        /// Begins this instance.
        /// </summary>
        public void Begin()
        {
            _transaction = _session.BeginTransaction();
        }
    }
}
