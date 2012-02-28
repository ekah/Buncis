using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Web.Common.Dependency
{
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        public IDependencyResolver CreateInstance()
        {
            return new DependencyResolver() as IDependencyResolver;
        }
    }
}