
using System;
using System.Collections.Generic;

namespace ShiftAssist.Models
{
    /// <summary>
    /// Violation of rule that worker must have a 24-hour day off each week averaged over a four-week period.
    /// </summary>
    class ViolationWeeklyDayOff : Violation
    {

        public ViolationWeeklyDayOff(List<Shift> shifts)
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
