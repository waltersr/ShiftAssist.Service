using System;
using System.Collections.Generic;
using System.Web.Http;
using ShiftAssist.Models;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Linq;
using ShiftAssist.DAL;
using ShiftAssist.Interfaces;

namespace ShiftAssist.Service.Code.Controllers
{
    [RoutePrefix("api/workers")]
    public class WorkerController : ApiController
    {
        private IRepository repos;

        /// <summary>
        /// Get specified worker.
        /// GET api/workers/[id]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Worker))]
        public async Task<IHttpActionResult> GetWorker(int id)
        {
            Worker worker;

            using (repos = new Repository())
            {
                worker = await repos.GetWorker(id);
            }

            return Ok(worker);
        }

        /// <summary>
        /// Get all workers.
        /// GET api/workers
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Worker>> GetWorkers()
        {
            IList<Worker> workers;

            using (repos = new Repository())
            {
                workers = await repos.GetWorkers();
            }

            return workers;
        }

        /// <summary>
        /// Get all violations that have occurred for a worker in the specified time frame.
        /// GET api/workers/[id]/violations
        /// </summary>
        /// <param name="id"></param>
        [Route("{id}/violations")]
        public async Task<IList<Violation>> GetWorkerViolations(int id, DateTime start, DateTime end)
        {
            Worker worker;

            using (repos = new Repository())
            {
                worker = await repos.GetWorker(id);
            }

            return await Task.Run(() => worker.CheckForViolations(start, end));
        }

    }
}
