using System;

using ShiftAssist.Models;

namespace ShiftAssist.Service
{
    static class WorkerFactory
    {
        static Worker CreateWorker(Type workerType)
        {
            Worker worker;

            if (workerType.Equals(typeof(Resident)))
                worker = new Resident();
            else 
                throw new ArgumentOutOfRangeException("workerType", workerType, "Invalid type of Worker");

            return worker;
        }
    }
}
