﻿using System;

namespace Buncis.Framework.Core.Infrastructure.IoC
{
    public interface IDependencyResolver : IDisposable
    {
        T Resolve<T>();
    }
}