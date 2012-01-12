using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using NHibernate;
using Buncis.Core.Repositories;
using Buncis.Data.Repository;
using StructureMap.Graph;
using NHibernate.Burrow;
using Buncis.Framework.Core.Infrastructure;

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
                catch (Exception ex)
                {
                    //throw;
                }
                return null;
            });
            Scan(o =>
            {
                o.AssemblyContainingType<CategoryRepository>();
                o.Convention<DefaultConventionScanner>();
            });
            For<IUnitOfWork>().HttpContextScoped().Use<NHUnitOfWork>();
        }
    }
}
