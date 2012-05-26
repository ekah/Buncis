using Buncis.Core.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using Buncis.Core.Services.Pages;
using Buncis.Services.Pages;

namespace Buncis.Services.Common
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(p =>
            {
                p.AssemblyContainingType<IDynamicPageService>();
                p.AssemblyContainingType<DynamicPageService>();
                p.Convention<DefaultConventionScanner>();
            });
        }
    }
}