using System;
using System.Web;
using System.Web.Routing;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Web.Common.Dependency;
using Buncis.Web.Common.RouteHandler;
using Buncis.Web.Common.DynamicControls;
using NHibernate.Burrow;

namespace Buncis.Web
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            IDependencyResolverFactory dependencyResolverFactory = new DependencyResolverFactory();
            IoC.InitializeIoC(dependencyResolverFactory);

            var routingConfig = new RoutingConfiguration();
            routingConfig.RegisterRoutes(RouteTable.Routes);

            DynamicControlsContainer.InitializeDynamicControls();
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        private void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        private void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer
            // or SQLServer, the event is not raised.
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
			new BurrowFramework().InitWorkSpace();
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
			new BurrowFramework().CloseWorkSpace();
        }
    }
}