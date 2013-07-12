using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Laurus.Pfeffer.Server.Controller
{
	public class GetJobController : ApiController
	{
		public GetJobController(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		private IJobStore _jobStore;
	}
}
