using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Admin.Cmd
{
	public class Publisher
	{
		public void PublishJobToServer(Entity.Job job)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["Server"]);

			var response = client.PostAsJsonAsync("api/add", job).Result;
		}

		public void ListJobs()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["Server"]);
			var response = client.GetAsync("api/list").Result;
			if (response.IsSuccessStatusCode)
			{
				var jobs = response.Content.ReadAsAsync<IEnumerable<Entity.Job>>().Result;
				foreach (var j in jobs)
				{
					Console.WriteLine("{0}: {1}", j.Id, j.Name);
				}
			}
			else
			{
				Console.WriteLine("Error listing available jobs: {0} {1}", (int)response.StatusCode, response.ReasonPhrase);
			}
		}

		public void RunJob(int id, string routes = null)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["Server"]);
			var queryString = String.Format("api/run?id={0}&routes={1}", id, routes);
			var response = client.GetAsync(queryString).Result;
		}

		public void GetDetails(int id)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["Server"]);
			var response = client.GetAsync(String.Format("api/getjob?id={0}", id)).Result;
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
		}

		public void UploadPackage(int id, string packageFile)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["Server"]);
			var content = new StreamContent(System.IO.File.OpenRead(packageFile));
			var result = client.PostAsync(String.Format("api/upload?jobId={0}", id), content).Result;
			Console.WriteLine(result.StatusCode);
		}
	}
}
