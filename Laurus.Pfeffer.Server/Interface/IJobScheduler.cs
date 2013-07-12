using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server.Interface
{
	public interface IJobScheduler
	{
		// add a job and call IJobPublisher when it executes
		void ScheduleJob(string cron, Entity.Job job);
	}
}
