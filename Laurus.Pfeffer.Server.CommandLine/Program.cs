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
			//var service = container.Resolve<IService>();
			//service.Start();
			//HostFactory.Run(x =>
			//{
			//	x.Service<IService>(s =>
			//	{
			//		s.ServiceName = "Pfeffer Server";
			//	});
			//});
			var server = container.Resolve<IServerQueue>();
			server.Send(new TestMessage() { Content = "blah blah blah" }, "all");
		}

		static IWindsorContainer BuildContainer(string directory)
		{
			var container = new WindsorContainer();
			container.Install(FromAssembly.InDirectory(new AssemblyFilter(directory, "Laurus*.dll")));
			return container;
		}
	}
}
