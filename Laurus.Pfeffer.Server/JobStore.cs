using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
	public class JobStore : IJobStore
	{
		Entity.Job IJobStore.GetJobById(int id)
		{
			return _jobs[id];
		}

		IEnumerable<Entity.Job> IJobStore.GetAll()
		{
			return _jobs.Select(x => x.Value);
		}

		int IJobStore.Add(Entity.Job job)
		{
			int id = new Random().Next(1000);
			job.Id = id;
			_jobs.Add(id, job);
			return id;
		}

		private IDictionary<int, Entity.Job> _jobs;
	}
}
