using Laurus.Pfeffer.Messages;
using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
	public class JobPublisher : IJobPublisher
	{
		public JobPublisher(IServerQueue queue)
		{
			_queue = queue;
		}

		void IJobPublisher.Publish(Entity.Job job)
		{
			var message = new TriggerMessage(job.Id);
			_queue.Send(message, job.Route);
		}

		private IServerQueue _queue;
	}
}
