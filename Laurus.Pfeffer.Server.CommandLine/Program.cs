using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Laurus.Pfeffer.Messages;
using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Laurus.Pfeffer.Server.CommandLine
{
	class Program
	{
		static void Main(string[] args)
		{
			var cd = System.IO.Directory.GetCurrentDirectory();
			var container = BuildContainer(cd);
			HostFactory.Run(x =>
			{
				x.Service(settings => container.Resolve<ServiceControl>());
				x.RunAsLocalService();
				x.SetDescription("Distributed task execution");
				x.SetDisplayName("Laurus.Pfeffer");
				x.SetServiceName("LaurusPfeffer");
				x.StartAutomatically();
			});

			// for testing only
			//var server = container.Resolve<IServerQueue>();
			//server.Send(new TestMessage() { Content = "blah blah blah" }, "all");
		}

		static IWindsorContainer BuildContainer(string directory)
		{
			var container = new WindsorContainer();
			container.Install(FromAssembly.InDirectory(new AssemblyFilter(directory, "Laurus*.dll")));
			container.Register(Component.For<ServiceControl>().ImplementedBy<ServiceController>());
			return container;
		}
	}
}
