using System;
using System.Collections.Generic;

namespace ShiftAssist.Models
{
    /// <summary>
    /// Violation of rule that a worker must have a minimum of 8 hours off between shifts.
    /// </summary>
    class ViolationShiftBreakHrs : Violation
    {

        public ViolationShiftBreakHrs(List<Shift> shifts)
        {
            //TODO: Implement method.
            throw new NotImplementedException();
        }


        public override bool HasViolationOccurred(List<Shift> workerShifts)
        {
            //TODO: Implement method.
            throw new NotImplementedException();
        }
    }
}
