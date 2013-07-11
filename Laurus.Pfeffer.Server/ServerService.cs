using Laurus.Pfeffer.Messages;
using Laurus.Pfeffer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server
{
    public class ServerService : IService
    {
		public ServerService(IServerQueue messageQueue)
		{
			_messageQueue = messageQueue;
		}

		void IService.Start()
		{
			_messageQueue.Send(new TestMessage() { Content = "hello im starting" }, "");
		}

		void IService.Stop()
		{
			throw new NotImplementedException();
		}

		private IServerQueue _messageQueue;
	}
}
