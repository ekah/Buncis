using Buncis.Data.Repository;
using NHibernate;
using NHibernate.Burrow;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Buncis.Data.Common
{
	public class DataRegistry : Registry
	{
		public DataRegistry()
		{
			For<ISession>().HybridHttpOrThreadLocalScoped().Use(s =>
			{
				var burrowFramework = new BurrowFramework();
				try
				{
					if (!burrowFramework.WorkSpaceIsReady)
					{
						burrowFramework.InitWorkSpace();
					}
					return burrowFramework.GetSession();
				}
				catch
				{
					//throw;
				}
				return null;
			});
			Scan(o =>
			{
				o.AssemblyContainingType<MembershipRepository>();
				o.Convention<DefaultConventionScanner>();
			});
		}
	}
}