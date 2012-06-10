using Buncis.Data.Common;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.Settings;
using Buncis.Framework.Core.Membership;
using Buncis.Web.Common.Membership;
using StructureMap;
using StructureMap.Configuration.DSL;
using Buncis.Web.Common.DynamicControls;
using NHibernate;
using NHibernate.Burrow;

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
            For<IWebMembership>().Use<AspNetMembership>();
            For<IMembership>().Use<AspNetMembership>();
            For<IDynamicControlsResolver>().Use<DynamicControlsResolver>();

            For<ISession>().Use(s =>
            {
                try
                {
                    var burrowFramework = new BurrowFramework();
                    var debugSession = burrowFramework.GetSession();
                    return debugSession;
                }
                catch
                {
                    //throw;
                }

                return null;
            });
        }
    }
}