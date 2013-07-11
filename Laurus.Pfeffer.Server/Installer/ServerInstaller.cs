using Castle.MicroKernel.Registration;
using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server.Installer
{
	public class ServerInstaller : IWindsorInstaller
	{
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(Component.For<IService>().ImplementedBy<ServerService>());
			container.Register(Component.For<IServerQueue>().ImplementedBy<ServerQueue>());
			// TODO: why doesn't this work
			//container.Register(Classes.FromThisAssembly());
		}
	}
}
