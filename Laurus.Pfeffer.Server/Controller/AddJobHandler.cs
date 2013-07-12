﻿using Laurus.Pfeffer.Server.Interface;
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

		public string Get(string name)
		{
			var id = 69;
			_jobStore.Add(new Entity.Job() { Name = name, Id = id });
			return "id = 69";
		}

		private IJobStore _jobStore;
	}
}
