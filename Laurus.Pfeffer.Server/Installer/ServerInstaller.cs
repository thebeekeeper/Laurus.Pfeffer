using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Laurus.Pfeffer.Server.Controller;
using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Laurus.Pfeffer.Server.Installer
{
	public class ServerInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(Component.For<IService>().ImplementedBy<ServerService>());
			container.Register(Component.For<IServerQueue>().ImplementedBy<ServerQueue>());
			container.Register(Component.For<IHttpListener>().ImplementedBy<WebApiHttpListener>());
			container.Register(Component.For<IJobStore>().ImplementedBy<JobStore>());
			container.Register(Component.For<IJobPublisher>().ImplementedBy<JobPublisher>());

			container.Register(Types.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped());
			container.Register(Component.For<IDependencyResolver>().ImplementedBy<WindsorDependencyResolver>());
			//container.Register(Component.For<HttpRequestHandler>().Named("addjob").ImplementedBy<AddJobHandler>());
			//container.Register(Component.For<HttpRequestHandler>().Named("getjob").ImplementedBy<GetJobHandler>());
			//container.Register(Component.For<IHandlerFactory>().ImplementedBy<WindsorHandlerFactory>());
			// TODO: get rid of service locator in WindsorHandlerFactory
			container.Register(Component.For<IWindsorContainer>().Instance(container).LifestyleSingleton());

			// TODO: why doesn't this work
			//container.Register(Classes.FromThisAssembly());
		}
	}
}
