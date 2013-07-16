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
		public JobStore()
		{
			_jobs = new List<Entity.Job>();
		}

		Entity.Job IJobStore.GetJobById(int id)
		{
			return _jobs.FirstOrDefault(j => j.Id == id);
		}

		IEnumerable<Entity.Job> IJobStore.GetAll()
		{
			return _jobs;
		}

		int IJobStore.Add(Entity.Job job)
		{
			int id = new Random().Next(1000);
			job.Id = id;
			_jobs.Add(job);
			return id;
		}

		private IList<Entity.Job> _jobs;
	}
}
