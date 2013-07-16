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

		public IEnumerable<Entity.Job> Get()
		{
			return _jobStore.GetAll();
		}

		private IJobStore _jobStore;
	}
}
