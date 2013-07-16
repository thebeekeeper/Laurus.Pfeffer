using Laurus.Pfeffer.Client.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client
{
    public class ClientQueue : IClientQueue
    {
		private static readonly string EXCHANGE_NAME = "pfeffer_exchange";

		public ClientQueue(ISubscriptionStore subscriptions, IJobExecutor executor)
		{
			_subscriptions = subscriptions;
			_executor = executor;
		}

		void IClientQueue.Receive()
		{
			// read topics from subscribed routes
			var topics = _subscriptions.Read().Select(x => x.Route);

			ConnectionFactory factory = new ConnectionFactory();
			factory.HostName = "localhost";
			using (IConnection connection = factory.CreateConnection())
			using (IModel channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(EXCHANGE_NAME, "topic");
				string queue_name = channel.QueueDeclare();

				foreach (string bindingKey in topics)
				{
					Console.WriteLine("Subscribing to {0}", bindingKey);
					channel.QueueBind(queue_name, EXCHANGE_NAME, bindingKey);
				}

				Console.WriteLine(" [*] Waiting for messages. " +
								  "To exit press CTRL+C");

				QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
				channel.BasicConsume(queue_name, true, consumer);

				while (true)
				{
					BasicDeliverEventArgs ea =
						(BasicDeliverEventArgs)consumer.Queue.Dequeue();

					byte[] body = ea.Body;
					string message = System.Text.Encoding.UTF8.GetString(body);
					string routingKey = ea.RoutingKey;
					Console.WriteLine(" [x] Received '{0}':'{1}'",
									  routingKey, message);
					_executor.Execute(Int32.Parse(message));
				}
			}
		}

		private ISubscriptionStore _subscriptions;
		private IJobExecutor _executor;
	}
}
