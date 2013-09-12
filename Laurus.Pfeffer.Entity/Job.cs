using Newtonsoft.Json;
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
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Route { get; set; }
		public string Executable { get; set; }
		public string[] Arguments { get; set; }
		public bool HasPackage { get; set; }
	}
}
