using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Web.Common.Dependency
{
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        #region IDependencyResolverFactory Members

        public IDependencyResolver CreateInstance()
        {
            return new DependencyResolver();
        }

        #endregion
    }
}