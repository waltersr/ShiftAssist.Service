using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftAssist.Models
{
    public class Resident : Worker
    {
        public Resident() : base()
        {
 
        }

        public override List<Violation> CheckForViolations()
        {
            //ViolationsToCheck.ForEach(v => v.)
            //TODO: Implement Resident.CheckForViolations()
            throw new NotImplementedException();
        }

        public override void SetViolationsToCheck()
        {
            ViolationsToCheck.Add(new ViolationShiftBreakHrs(Shifts));
            ViolationsToCheck.Add(new ViolationShiftWorkedHrs(Shifts));
            ViolationsToCheck.Add(new ViolationWeeklyDayOff(Shifts));
            ViolationsToCheck.Add(new ViolationWeeklyWorkedHrs(Shifts));
        }
    }
}