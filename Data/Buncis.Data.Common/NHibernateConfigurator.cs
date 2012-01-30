using Buncis.Data.Domain.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Burrow;
using NHibernate.Burrow.Configuration;

namespace Buncis.Data.Common
{
    public class NHibernateConfigurator : IConfigurator
    {
        public void Config(IPersistenceUnitCfg puCfg, NHibernate.Cfg.Configuration nhCfg)
        {
            Fluently.Configure(nhCfg)
                .Database(MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("BuncisConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
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
    }
}