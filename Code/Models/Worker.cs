using System.Collections.Generic;
using ShiftAssist.Interfaces;

namespace ShiftAssist.Models
{
    enum WorkerType { Resident };

    public abstract class Worker : IViolationCheck
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        //List<Facility> Facilities { get; set; }
        public virtual List<Shift> Shifts { get; protected set; }
        public virtual List<Violation> ViolationsToCheck { get; protected set; }
        public virtual List<Violation> ViolationsOccurred { get; protected set; }

        public abstract void SetViolationsToCheck();
        public abstract List<Violation> CheckForViolations();

        public Worker()
        {
            SetViolationsToCheck();
            ViolationsOccurred = CheckForViolations();
        }
    }
}