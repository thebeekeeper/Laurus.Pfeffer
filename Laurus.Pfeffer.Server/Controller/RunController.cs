using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Laurus.Pfeffer.Server.Controller
{
	public class RunController : ApiController
	{
		public RunController(IJobStore jobStore, IJobPublisher jobPublisher)
		{
			_jobStore = jobStore;
			_jobPublisher = jobPublisher;
		}

		public void Get(int id, string routes = null)
		{
			var job = _jobStore.GetJobById(id);
			if (routes != null)
			{
				var newJob = new Entity.Job()
				{
					Name = job.Name,
					Executable = job.Executable,
					Route = routes,
					Id = job.Id,
				};
				_jobPublisher.Publish(newJob);
			}
			else
			{
				_jobPublisher.Publish(job);
			}
		}

		private IJobStore _jobStore;
		private IJobPublisher _jobPublisher;
	}
}
