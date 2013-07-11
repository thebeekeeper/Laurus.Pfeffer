using Laurus.Pfeffer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server.Interface
{
	public interface IServerQueue
	{
		void Send(IMessage message, string route);
	}
}
