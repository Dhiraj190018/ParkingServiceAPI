using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Wcf;
using ParkingServiceAPI.Common;
using ParkingServiceAPI.DataAccess;
using ParkingServiceAPI.DataContract;

namespace ParkingServiceAPI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ParkingServiceUtilities>().As<IParkingServiceUtilities>();
            builder.RegisterType<ParkingServiceDatabaseAccess>().As<IParkingServiceDatabaseAccess>();

            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>().SingleInstance();
            builder.RegisterType<ParkingServiceImplementation>().As<IParkingServiceImplementation>();
            builder.RegisterType<ParkingFeesCalculator>().As<IParkingFeesCalculator>();

            // Register service
            builder.RegisterType<ParkingService>().As<IParkingService>();

            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}