﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server.Interface
{
	public interface IJobPublisher
	{
		void Publish(Entity.Job job);
	}
}
