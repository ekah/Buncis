using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Data.Common;
using StructureMap;
using NHibernate;
using StructureMap.Graph;
using Buncis.Services.Common;

namespace Buncis.Web.Common.IoC
{
    public class DependencyResolver : DisposableResource, IDependencyResolver
    {
        public DependencyResolver()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.AssemblyContainingType(GetType());
                    y.LookForRegistries();
                    y.Convention<DefaultConventionScanner>();
                });
                x.AddRegistry<DataRegistry>();
                x.AddRegistry<WebRegistry>();
                x.AddRegistry<ServiceRegistry>();
            });
        }

        public T Resolve<T>()
        {
            return ObjectFactory.Container.GetInstance<T>();
        }
    }
}
