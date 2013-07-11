using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;

namespace Laurus.Pfeffer.Server.HttpHandlers
{
	public class GetJobHandler : HttpRequestHandler
	{
		public GetJobHandler(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public override HttpResponse Handle(HttpRequest httpRequest)
		{
			// return _jobStore.GetPackage(id);
			return new HttpResponse(HttpResponseCode.Ok, "get a job sea cow");
		}

		private IJobStore _jobStore;
	}
}
