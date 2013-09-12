using Laurus.Pfeffer.Server.Interface;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laurus.Pfeffer.Server
{
	public class JobStore : IJobStore
	{
		public JobStore(IDocumentSession session)
		{
			_session = session;
		}

		Entity.Job IJobStore.GetJobById(int id)
		{
			var query = string.Format("jobs/{0}", id);
			var job = _session.Load<Entity.Job>(query);
			return job;
		}

		IEnumerable<Entity.Job> IJobStore.GetAll()
		{
			return _session.Query<Entity.Job>();
		}

		int IJobStore.Add(Entity.Job job)
		{
			_session.Store(job);
			_session.SaveChanges();
			return job.Id;
		}

		void IJobStore.AttachFile(int jobId, string filename)
		{
			var id = String.Format("jobs/{0}", jobId);
			var data = System.IO.File.Open(filename, System.IO.FileMode.Open);
			_session.Advanced.DocumentStore.DatabaseCommands.PutAttachment(id, null, data, new Raven.Json.Linq.RavenJObject() {{ "Description", "Job Package" }});
		}

		Stream IJobStore.GetAttachment(int jobId)
		{
			var id = String.Format("jobs/{0}", jobId);
			var a = _session.Advanced.DocumentStore.DatabaseCommands.GetAttachment(id);
			return a.Data();
		}

		private IDocumentSession _session;
	}
}
