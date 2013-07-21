using Laurus.Pfeffer.Messages;
using Laurus.Pfeffer.Server.Installer;
using Laurus.Pfeffer.Server.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
	public class ServerQueue : IServerQueue
	{
		private static readonly string EXCHANGE_NAME = "pfeffer_exchange";

		void IServerQueue.Send(IMessage message, string route)
		{
			// empty route is shorthand for all routes
			if (String.IsNullOrEmpty(route)) { route = "all"; }

			// TODO: figure out if there's a bettery way to init a queue every time we send a message
			ConnectionFactory factory = new ConnectionFactory();
			factory.HostName = "localhost";
			using (IConnection connection = factory.CreateConnection())
			{
				using (IModel channel = connection.CreateModel())
				{
					channel.ExchangeDeclare(EXCHANGE_NAME, "topic");
					channel.BasicPublish(EXCHANGE_NAME, route, null, message.Serialize());
				}
			}
		}
	}
}
