namespace Buncis.Framework.Core.Infrastructure.IoC
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}