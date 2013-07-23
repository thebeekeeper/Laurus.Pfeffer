using Laurus.Pfeffer.Client.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			Console.WriteLine("Starting job {0}", jobId);
			Console.WriteLine("From {0}", Environment.CurrentDirectory);
			Console.WriteLine("With command {0}", j.Executable);
			if (j.Executable.Contains("\\"))
			{
				var workingDir = j.Executable.Substring(0, j.Executable.LastIndexOf("\\"));
				Console.WriteLine("Starting from {0}", workingDir);
				var startInfo = new ProcessStartInfo();
				startInfo.WorkingDirectory = workingDir;
				startInfo.FileName = j.Executable.Substring(j.Executable.LastIndexOf("\\") + 1);
				Console.WriteLine("file name is {0}", startInfo.FileName);
				Process.Start(startInfo);
			}
			else
			{
				System.Diagnostics.Process.Start(j.Executable);
			}
		}

		private IClientJobStore _jobStore;
	}
}
