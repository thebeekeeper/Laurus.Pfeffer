﻿using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;

namespace Laurus.Pfeffer.Server.HttpHandlers
{
	public class AddJobHandler : HttpRequestHandler
	{
		public AddJobHandler(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public override HttpResponse Handle(HttpRequest httpRequest)
		{
			return new HttpResponse(HttpResponseCode.Ok, "adding job");
		}

		private IJobStore _jobStore;
	}
}
