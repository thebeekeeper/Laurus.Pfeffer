using Castle.Windsor;
using Laurus.Pfeffer.Server.Interface;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
	//public class WindsorJobFactory : IJobFactory
	//{
	//	public WindsorJobFactory(IWindsorContainer container)
	//	{
	//		_container = container;
	//	}

	//	Quartz.IJob IJobFactory.NewJob(TriggerFiredBundle bundle, Quartz.IScheduler scheduler)
	//	{
	//		return _container.Resolve<IJobPublisher>();
	//	}

	//	void IJobFactory.ReturnJob(Quartz.IJob job)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	private IWindsorContainer _container;
	//}
}
