using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Buncis.Core.Infrastructures;

namespace Buncis.Web.Common
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            //For<ISystemSettings>().Use<SystemSettings>().f
        }
    }
}
