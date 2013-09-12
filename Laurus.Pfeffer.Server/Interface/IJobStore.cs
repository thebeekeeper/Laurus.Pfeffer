using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Pfeffer.Server.Interface
{
	public interface IJobStore
	{
		Entity.Job GetJobById(int id);

		IEnumerable<Entity.Job> GetAll();

		int Add(Entity.Job job);

		void AttachFile(int jobId, string filename);

		Stream GetAttachment(int jobId);
	}
}
