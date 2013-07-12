using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
	//public class WindsorHandlerFactory : IHandlerFactory
	//{
	//	// TODO: refactor this to not be a service locator
	//	// - can it take an array of HttpRequestHandlers?
	//	public WindsorHandlerFactory(IWindsorContainer container)
	//	{
	//		_container = container;
	//	}

	//	HttpRequestHandler IHandlerFactory.GetHandler(string name)
	//	{
	//		if (_container.Kernel.HasComponent(name))
	//		{
	//			return _container.Resolve<HttpRequestHandler>(name);
	//		}
	//		else
	//		{
	//			return null;
	//		}
	//	}

	//	private IWindsorContainer _container;
	//}
}
