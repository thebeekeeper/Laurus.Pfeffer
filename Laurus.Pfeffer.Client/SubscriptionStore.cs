using Laurus.Pfeffer.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client
{
	public class SubscriptionStore : ISubscriptionStore
	{
		public SubscriptionStore()
		{
			_jobs = new List<Entity.Job>();
		}

		IEnumerable<Entity.Job> ISubscriptionStore.Read()
		{
			return _jobs;
		}

		void ISubscriptionStore.Write(Entity.Job job)
		{
			_jobs.Add(job);
		}

		private IList<Entity.Job> _jobs;
	}
}
