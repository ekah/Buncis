using Buncis.Framework.Core.Services.Pages;
using Buncis.Services.Pages;
using Buncis.Services.Url;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using Buncis.Data.Domain.News;

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

			For<IUrlEngine<NewsItem>>().Use<NewsUrlEngine>();
		}
	}
}