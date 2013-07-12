using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;

namespace Laurus.Pfeffer.Server
{
	// stolen! http://cangencer.wordpress.com/2012/12/22/integrating-asp-net-web-api-with-castle-windsor/
	public class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
	{
		private readonly IKernel container;

		public WindsorDependencyResolver(IKernel container)
		{
			this.container = container;
		}

		public IDependencyScope BeginScope()
		{
			return new WindsorDependencyScope(this.container);
		}

		public object GetService(Type serviceType)
		{
			return this.container.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.container.ResolveAll(serviceType).Cast<object>();
		}

		public void Dispose() { }
	}

	public class WindsorDependencyScope : IDependencyScope
	{
		private readonly IKernel container;
		private readonly IDisposable scope;

		public WindsorDependencyScope(IKernel container)
		{
			this.container = container;
			this.scope = container.BeginScope();
		}

		public object GetService(Type serviceType)
		{
			return this.container.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.container.ResolveAll(serviceType).Cast<object>();
		}

		public void Dispose()
		{
			this.scope.Dispose();
		}
	}

}
