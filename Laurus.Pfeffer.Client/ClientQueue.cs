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

		void IClientQueue.Receive(string[] topics)
		{
			ConnectionFactory factory = new ConnectionFactory();
			factory.HostName = "localhost";
			using (IConnection connection = factory.CreateConnection())
			using (IModel channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(EXCHANGE_NAME, "topic");
				string queue_name = channel.QueueDeclare();

				foreach (string bindingKey in topics)
				{
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
				}
			}
		}
	}
}
