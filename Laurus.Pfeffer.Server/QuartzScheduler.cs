using Castle.Windsor;
using Laurus.Pfeffer.Server.Interface;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
	public class QuartzScheduler : IJobScheduler
	{
		public QuartzScheduler(IWindsorContainer container)
		{
			Quartz.ISchedulerFactory schedFact = new StdSchedulerFactory();
			_scheduler = schedFact.GetScheduler();
			//_scheduler.JobFactory = new WindsorJobFactory(container);
		}

		void IJobScheduler.ScheduleJob(string cron, Entity.Job job)
		{
			var jobDetail = JobBuilder.Create()
				.OfType<JobPublisher>()
				.WithIdentity(Guid.NewGuid().ToString())
				.Build();
			ITrigger trigger = default(ITrigger);
			trigger = TriggerBuilder.Create().WithCronSchedule(cron).ForJob(jobDetail).Build();
			_scheduler.ScheduleJob(jobDetail, trigger);
		}

		private IScheduler _scheduler;
	}
}
