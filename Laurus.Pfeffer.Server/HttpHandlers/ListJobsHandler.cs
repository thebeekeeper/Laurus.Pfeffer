using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;

namespace Laurus.Pfeffer.Server.HttpHandlers
{
	public class ListJobsHandler : HttpRequestHandler
	{
		public ListJobsHandler(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public override HttpResponse Handle(HttpRequest httpRequest)
		{
			var rval = "";
			return new HttpResponse(HttpResponseCode.Ok, rval);
		}

		private IJobStore _jobStore;
	}
}
