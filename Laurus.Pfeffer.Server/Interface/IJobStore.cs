﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server.Interface
{
	public interface IJobStore
	{
		Entity.Job GetJobById(int id);

		IEnumerable<Entity.Job> GetAll();

		int Add(Entity.Job job);
	}
}
