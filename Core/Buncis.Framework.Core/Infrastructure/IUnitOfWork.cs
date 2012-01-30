using System;

namespace Buncis.Framework.Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();

        void Commit();

        void Rollback();
    }
}