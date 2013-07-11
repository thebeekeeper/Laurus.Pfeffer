using Laurus.Pfeffer.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			IClientQueue client = new ClientQueue();
			client.Receive(new[] { "all" });
		}
	}
}
