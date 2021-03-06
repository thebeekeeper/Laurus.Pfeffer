﻿using Laurus.Pfeffer.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Client
{
	public class ClientJobStore : IClientJobStore
	{
		Entity.Job IClientJobStore.GetJob(int id)
		{
			var server = System.Configuration.ConfigurationManager.AppSettings["QueueHost"];
			// TODO: cache jobs here - just downloading for now
			var baseUrl = new Uri(String.Format("http://{0}:8880/", server));
			var client = new HttpClient();
			client.BaseAddress = baseUrl;
			//client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			var response = client.GetAsync(String.Format("/api/GetJob/{0}", id)).Result;
			var job = response.Content.ReadAsAsync<Entity.Job>().Result;
			return job;
		}
	}
}
