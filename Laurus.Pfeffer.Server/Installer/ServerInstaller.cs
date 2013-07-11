using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Laurus.Pfeffer.Server.HttpHandlers;
using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;

namespace Laurus.Pfeffer.Server.Installer
{
	public class ServerInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(Component.For<IService>().ImplementedBy<ServerService>());
			container.Register(Component.For<IServerQueue>().ImplementedBy<ServerQueue>());
			container.Register(Component.For<IHttpListener>().ImplementedBy<HttpListener>());

			container.Register(Component.For<HttpRequestHandler>().Named("addjob").ImplementedBy<AddJobHandler>());
			container.Register(Component.For<IHandlerFactory>().ImplementedBy<WindsorHandlerFactory>());
			// TODO: get rid of service locator in WindsorHandlerFactory
			container.Register(Component.For<IWindsorContainer>().Instance(container).LifestyleSingleton());

			// TODO: why doesn't this work
			//container.Register(Classes.FromThisAssembly());
		}
	}
}
