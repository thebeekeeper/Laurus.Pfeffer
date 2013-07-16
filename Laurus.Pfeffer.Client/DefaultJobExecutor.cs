using Laurus.Pfeffer.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client
{
	public class DefaultJobExecutor : IJobExecutor
	{
		public DefaultJobExecutor(IClientJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		void IJobExecutor.Execute(int jobId)
		{
			// TODO: this is messed up
			var j = _jobStore.GetJob(jobId);
			System.Diagnostics.Process.Start(j.Executable);
		}

		private IClientJobStore _jobStore;
	}
}
