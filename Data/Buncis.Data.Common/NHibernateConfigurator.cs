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
            //Fluently.Configure(nhCfg)
            //    .Database(MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("BuncisConnectionString")))
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
            //    .BuildConfiguration();

            Fluently.Configure(nhCfg)
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("BuncisConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PageMap>())
                .BuildConfiguration();
        }

        public void Config(IBurrowConfig val)
        {
            val.PersistenceUnitCfgs.Add(new PersistenceUnitElement
                                            {
                                                Name = "PersistenceUnit1",
                                                NHConfigFile = null
                                            });
        }

        #endregion
    }
}