using Buncis.Data.Domain.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Burrow;
using NHibernate.Burrow.Configuration;
using NHibernate.Cfg;

namespace Buncis.Data.Common
{
    public class NHibernateConfigurator : IConfigurator
    {
        #region IConfigurator Members

        public void Config(IPersistenceUnitCfg puCfg, Configuration nhCfg)
        {
            nhCfg.SetProperty("connection.release_mode", "auto");
            //nhCfg.SetProperty("current_session_context_class", 
            //    "uNhAddIns.SessionEasier.Contexts.ThreadLocalSessionContext, uNhAddIns");

            Fluently.Configure(nhCfg)
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("BuncisConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PageMap>())
                .BuildConfiguration();
                //.BuildSessionFactory();
        }

        public void Config(IBurrowConfig val)
        {
            val.PersistenceUnitCfgs.Add(new PersistenceUnitElement
            {
                Name = "bPersistenceUnit",
                NHConfigFile = null
            });
        }

        #endregion
    }
}