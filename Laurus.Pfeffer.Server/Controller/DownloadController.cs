using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Laurus.Pfeffer.Server.Interface;

namespace Laurus.Pfeffer.Server.Controller
{
	public class DownloadController : ApiController
	{
		public DownloadController(IJobStore jobStore)
		{
			_jobStore = jobStore;
		}

		public HttpResponseMessage Get(int id)
		{
			var s = _jobStore.GetAttachment(id);
			var rval = new HttpResponseMessage();
			rval.Content = new StreamContent(s);
			rval.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			return rval;
		}

		private IJobStore _jobStore;
	}
}
