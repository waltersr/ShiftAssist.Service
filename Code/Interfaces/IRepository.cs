using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShiftAssist.Models;


namespace ShiftAssist.Interfaces
{
    interface IRepository : IDisposable
    {
        Task<Worker> GetWorker(int id);
        Task<IList<Worker>> GetWorkers();
    }
}
