using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Messages
{
	public interface IMessage
	{
		// TODO: this should probably be a json string with data that allows a client to Activator.CreateInstance
		// of the job type along with the job params
		byte[] Serialize();
	}
}
