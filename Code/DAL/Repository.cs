using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ShiftAssist.Interfaces;
using ShiftAssist.Models;

namespace ShiftAssist.DAL
{
    class Repository : IRepository
    {
        private ShiftAssistContext context;


        public Repository()
        {
            context = new ShiftAssistContext();
        }


        /// <summary>
        /// Get worker with the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Worker> GetWorker(int id) => 
            await context.Workers.SingleOrDefaultAsync(w => w.Id == id);


        /// <summary>
        /// Get all workers.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Worker>> GetWorkers() => 
            await context.Workers.ToListAsync();


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
