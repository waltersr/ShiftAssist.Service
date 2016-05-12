using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShiftAssist.Interfaces;

namespace ShiftAssist.Models
{
    enum WorkerType { Resident };

    public abstract class Worker : IViolationCheck
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        
        public virtual List<Shift> Shifts { get; protected set; }
        public virtual List<Rule> RulesToCheck { get; protected set; }

        public abstract void SetRulesToCheck();
        public abstract IList<Violation> CheckForViolations(DateTime start, DateTime end);

        public Worker()
        {
            SetRulesToCheck();
            //ViolationsOccurred = CheckForViolations();
        }
    }
}