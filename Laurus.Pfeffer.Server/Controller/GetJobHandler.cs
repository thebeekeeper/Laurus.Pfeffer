using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;

namespace Laurus.Pfeffer.Server.Controller
{
	public class GetJobController : ApiController
	{
		public GetJobController(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public Entity.Job Get(int id)
		{
			return _jobStore.GetJobById(id);
		}

		private IJobStore _jobStore;
	}
}
