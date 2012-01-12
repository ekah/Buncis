using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.Infrastructure.IoC
{
    public interface IDependencyResolver : IDisposable
    {
        T Resolve<T>();
    }
}
