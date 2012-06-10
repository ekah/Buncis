using Buncis.Data.Repository.Pages;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Buncis.Data.Common
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(o =>
            {
                o.AssemblyContainingType<PageRepository>();
                o.Convention<DefaultConventionScanner>();
            });
        }
    }
}