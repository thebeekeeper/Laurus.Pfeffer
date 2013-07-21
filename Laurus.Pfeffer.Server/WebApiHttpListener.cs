using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.Dispatcher;
using System.Web.Http.Dependencies;

namespace Laurus.Pfeffer.Server
{
	public class HelloController : ApiController
	{
		public string Get()
		{
			return "Hello, world!";
		}
	}

	public class WebApiHttpListener : IHttpListener
	{
		public WebApiHttpListener(IDependencyResolver dependencyResolver)
		{
			_dependencyResolver = dependencyResolver;
		}

		void IHttpListener.Listen(int port)
		{
			// to register: netsh http add urlacl url=http://+:8880/ user=thebeekeeper as admin
			var config = new HttpSelfHostConfiguration("http://apollo:8880");
			config.DependencyResolver = _dependencyResolver;
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			var server = new HttpSelfHostServer(config);
			server.OpenAsync().Wait();
		}

		private IDependencyResolver _dependencyResolver;
	}
}
