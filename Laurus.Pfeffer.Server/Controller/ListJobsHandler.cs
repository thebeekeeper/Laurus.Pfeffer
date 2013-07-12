using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Laurus.Pfeffer.Server.Controller
{
	public class ListJobsController : ApiController
	{
		public ListJobsController(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public string Get()
		{
			return "jobs, hope, cash";
		}

		private IJobStore _jobStore;
	}
}
