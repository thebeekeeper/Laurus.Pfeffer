using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;

namespace Laurus.Pfeffer.Server
{
	public class HttpListener : IHttpListener
	{
		public HttpListener(IHandlerFactory handlerFactory)
		{
			_handlerFactory = handlerFactory;
		}

		void IHttpListener.Listen(int port)
		{
			HttpServer.Instance.Port = port;
			HttpServer.Instance.StartUp(_handlerFactory);
		}

		private IHandlerFactory _handlerFactory;
	}
}
