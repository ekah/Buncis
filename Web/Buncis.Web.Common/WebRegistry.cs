using Buncis.Core.Infrastructures;
using Buncis.Core.Membership;
using Buncis.Data.Common;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.Settings;
using Buncis.Framework.Core.Membership;
using Buncis.Web.Common.Membership;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Buncis.Web.Common
{
	public class WebRegistry : Registry
	{
		public WebRegistry()
		{
			For<IUnitOfWork>().HttpContextScoped().Use<NHUnitOfWork>();
			For<IPropertySettingsResolver>().Use<AppSettingsPropertySettingsResolver>();
			For<ISystemSettings>().Use(delegate()
			{
				var propertySettingsResolver = ObjectFactory.Container.GetInstance<IPropertySettingsResolver>();
				var settingsProvider = new SettingsProvider<SystemSettings>(propertySettingsResolver);
				return settingsProvider.ResolveSettings();
			});
			For<IMembershipStorage>().Use<WebMembershipStorage>();
			For<IMembership>().Use<CoreMembership>();
		}
	}
}