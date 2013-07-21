using Laurus.Pfeffer.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			ISubscriptionStore subscriptions = new SubscriptionStore();
			subscriptions.Write(new Laurus.Pfeffer.Entity.Job()
			{
				Name = "Test subscription",
				Route = "test"
			});

			subscriptions.Write(new Entity.Job()
			{
				Name = "hello",
				Route = "orange.dog"
			});

			subscriptions.Write(new Entity.Job()
			{
				Name = "all queue",
				Route = "all"
			});

			subscriptions.Write(new Entity.Job()
			{
				Name = "local queue",
				Route = Dns.GetHostName()
			});

			IJobExecutor executor = new DefaultJobExecutor(new ClientJobStore());
			IClientQueue client = new ClientQueue(subscriptions, executor);
			client.Receive();
			//client.Receive(new[] { "all" });
		}
	}
}
