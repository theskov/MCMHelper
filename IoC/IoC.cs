using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Shared.Interfaces;

namespace Shared
{
    public static class IoC
    {
        private static IWindsorContainer container;
        public static void BootstrapContainer()
        {
            container = new WindsorContainer()
               .Install(FromAssembly.This()
               );
        }

        public static IWindsorContainer ResolveContainer()
        {
            return container;
        }

        public static void TeardownContainer()
        {
            if (container == null) return;
            container.Dispose();
            container = null;
        }
    }

    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRunner>().ImplementedBy<Runner.Runner>());
            container.Register(Component.For<ISiteNavigator<IParser>>().ImplementedBy<MCMSiteNavigator.SiteNavigator>());
            container.Register(Component.For<IParser>().ImplementedBy<MCMParser.MCMParser>());
        }
    }
}
