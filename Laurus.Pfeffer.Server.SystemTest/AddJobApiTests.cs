using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace Laurus.Pfeffer.Server.SystemTest
{
	public class AddJobApiTests
	{
		[Fact]
		public void SimpleJobCanBeAddedAndRetrieved()
		{
			var baseUrl = new Uri("http://localhost:8880/");
			var client = new HttpClient();
			client.BaseAddress = baseUrl;
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			// create job
			var data = File.ReadAllText(@"c:\temp\manifest.json");
			//var content = new StreamContent(File.Open(@"c:\temp\manifest.json", FileMode.Open));
			var content = new StringContent(data);
			var response = client.PostAsync("/api/addjob", content).Result;
			var id = response.Content.ReadAsAsync<Int32>().Result;

			response = client.GetAsync(String.Format("/api/GetJob/{0}", id)).Result;
			var job = response.Content.ReadAsAsync<Entity.Job>().Result;
		}
	}
}
