using Buncis.Core.Infrastructures;
using Buncis.Data.Common;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.Settings;
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
                var propertySettingsResolver = StructureMap.ObjectFactory.Container.GetInstance<IPropertySettingsResolver>();
                var settingsProvider = new SettingsProvider<SystemSettings>(propertySettingsResolver);
                return settingsProvider.ResolveSettings();
            });
        }
    }
}