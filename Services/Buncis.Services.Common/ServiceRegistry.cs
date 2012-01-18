using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Buncis.Core.Services;
using StructureMap.Graph;

namespace Buncis.Services.Common
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(p =>
            {
                p.AssemblyContainingType<IProductService>();
                p.AssemblyContainingType<ProductService>();
                p.Convention<DefaultConventionScanner>();
            });
        }
    }
}
