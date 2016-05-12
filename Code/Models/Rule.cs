using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftAssist.Models
{
    public abstract class Rule
    {
        public abstract string Description { get; }

        public abstract IList<Violation> CheckForViolations(List<Shift> shifts, DateTime startDt, DateTime endDt); 
    }
}
