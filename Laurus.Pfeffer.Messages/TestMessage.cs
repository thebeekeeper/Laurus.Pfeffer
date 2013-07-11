using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Messages
{
    public class TestMessage : IMessage
    {
		public string Content { get; set; }

		byte[] IMessage.Serialize()
		{
			return Encoding.UTF8.GetBytes(Content);
		}
	}
}
