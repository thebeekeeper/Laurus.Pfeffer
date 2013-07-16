using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Laurus.Pfeffer.Server.Controller
{
	public class RunJobController : ApiController
	{
		public RunJobController(IJobStore jobStore, IJobPublisher jobPublisher)
		{
			_jobStore = jobStore;
			_jobPublisher = jobPublisher;
		}

		public void Get()
		{
			var job = _jobStore.GetAll().First();
			_jobPublisher.Publish(job);
		}

		private IJobStore _jobStore;
		private IJobPublisher _jobPublisher;
	}
}
