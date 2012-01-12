using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.Infrastructure.IoC
{
    public static class IoC
    {
        private static IDependencyResolver _resolver;

        /// <summary>
        /// Initializes the io C.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public static void InitializeIoC(IDependencyResolverFactory factory)
        {
            _resolver = factory.CreateInstance();
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _resolver.Resolve<T>();
        }
    }
}
