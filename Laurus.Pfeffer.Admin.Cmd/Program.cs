using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Admin.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new Publisher();
			switch (args[0])
			{
				case "/a":
					p.PublishJobToServer(JsonConvert.DeserializeObject<Entity.Job>(System.IO.File.ReadAllText(args[1])));
					break;
				case "/l":
					p.ListJobs();
					break;
				case "/r":
					if (args.Length > 2)
					{
						p.RunJob(Int32.Parse(args[1]), String.Join(",", args.Skip(2)));
					}
					else
					{
						p.RunJob(Int32.Parse(args[1]));
					}
					break;
				case "/d":
					p.GetDetails(Int32.Parse(args[1]));
					break;
				case "/u":
					// upload package
					var filename = args[1];
					var job = Int32.Parse(args[2]);
					p.UploadPackage(job, filename);
					break;
				default:
					Console.WriteLine("Unknown command {0}", args[0]);
					break;
			}
		}
	}
}
