using System.Collections.Generic;

namespace ShiftAssist.Models
{
    public abstract class Violation
    {
        public string Description { get; protected set; }

        public virtual List<Shift> OffendingShifts { get; protected set; }

        public abstract bool HasViolationOccurred(List<Shift> workerShifts);
    }
}
