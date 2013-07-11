using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Laurus.Pfeffer.Server.CommandLine
{
	public class ServiceController : ServiceControl
	{
		public ServiceController(IHttpListener httpListener)
		{
			_httpListener = httpListener;
		}

		public bool Start(HostControl hostControl)
		{
			_httpListener.Listen(1234);
			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			return true;
		}

		private IHttpListener _httpListener;
	}
}
