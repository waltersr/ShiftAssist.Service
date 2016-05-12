
using System;
using System.Collections.Generic;

namespace ShiftAssist.Models
{
    /// <summary>
    /// Violation of rule that worker's individual shift must not exceed 24 hours of continuous duty.
    /// </summary>
    class ViolationShiftWorkedHrs : Violation
    {

        public ViolationShiftWorkedHrs(List<Shift> shifts)
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
