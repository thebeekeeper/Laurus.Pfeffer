using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Laurus.Pfeffer.Server.Interface;

namespace Laurus.Pfeffer.Server.Controller
{
	public class UploadController : ApiController
	{
		public UploadController(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public HttpResponseMessage Post([FromUri]int jobId)
		{
			var task = this.Request.Content.ReadAsStreamAsync();
			task.Wait();
			Stream requestStream = task.Result;

			var fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()) + ".zip";
			try
			{
				Console.WriteLine("Saving job file to {0}", fileName);
				Stream fileStream = File.Create(fileName);
				requestStream.CopyTo(fileStream);
				fileStream.Close();
				requestStream.Close();
			}
			catch (IOException)
			{
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

			_jobStore.AttachFile(jobId, fileName);

			var response = new HttpResponseMessage();
			response.StatusCode = HttpStatusCode.Created;
			return response;
		}

		private IJobStore _jobStore;
	}
}
