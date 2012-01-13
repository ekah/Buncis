using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
