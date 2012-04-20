using Buncis.Core.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

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