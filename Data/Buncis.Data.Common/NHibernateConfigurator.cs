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
		public void Config(IPersistenceUnitCfg puCfg, Configuration nhCfg)
		{
			nhCfg.SetProperty("connection.release_mode", "auto");

			Fluently.Configure(nhCfg)
				.Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("BuncisConnectionString")))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PageMap>())
				.ExposeConfiguration(configuration => configuration.SetProperty(Environment.UseSqlComments, "false"))
				.BuildConfiguration();
		}

		public void Config(IBurrowConfig val)
		{
			val.PersistenceUnitCfgs.Add(new PersistenceUnitElement
			{
				Name = "bPersistenceUnit",
				NHConfigFile = null
			});
		}
	}
}