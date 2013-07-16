using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client.Interface
{
	public interface ISubscriptionStore
	{
		IEnumerable<Entity.Job> Read();
		void Write(Entity.Job job);
	}
}
