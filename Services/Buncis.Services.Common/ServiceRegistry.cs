using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Services.Pages;
using Buncis.Services.Url;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using Buncis.Data.Domain.News;
using Buncis.Data.Domain.Articles;
using Buncis.Data.Domain.DailyBread;

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
			For<IUrlEngine<ArticleItem>>().Use<ArticleUrlEngine>();
			For<IUrlEngine<DailyBreadItem>>().Use<DailyBreadUrlEngine>();
		}
	}
}