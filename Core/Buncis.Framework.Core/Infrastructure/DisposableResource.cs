using System;

namespace Buncis.Framework.Core.Infrastructure
{
    public abstract class DisposableResource : IDisposable
    {
        ~DisposableResource()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}