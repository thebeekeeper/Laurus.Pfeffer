﻿using Laurus.Pfeffer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client.Interface
{
	public interface IJobExecutor
	{
		void Execute(int jobId);
	}
}