using Laurus.Pfeffer.Server.Interface;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		private IDocumentSession _session;
	}
}
