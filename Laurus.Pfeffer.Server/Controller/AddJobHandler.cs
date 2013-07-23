using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Laurus.Pfeffer.Server.Controller
{
	public class AddJobController : ApiController
	{
		public AddJobController(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public int Get(string name)
		{
			var job = new Entity.Job() { Name = name, Executable = "notepad.exe" };
			_jobStore.Add(job);
			return job.Id;
		}

		public int Post([FromBody]Entity.Job job)
		{
			var id = _jobStore.Add(job);
			return id;
		}

		private IJobStore _jobStore;
	}
}
