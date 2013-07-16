using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Entity
{
	[Serializable]
	public class Job
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Route { get; set; }
		public string Executable { get; set; }
	}
}
