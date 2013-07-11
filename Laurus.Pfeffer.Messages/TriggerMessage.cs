using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Messages
{
	public class TriggerMessage : IMessage
	{
		public TriggerMessage(int jobId)
		{
			_jobId = jobId;
		}

		byte[] IMessage.Serialize()
		{
			return Encoding.UTF8.GetBytes(_jobId.ToString());
		}

		private int _jobId;
	}
}
