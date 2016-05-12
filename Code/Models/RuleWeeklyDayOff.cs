using System;
using System.Collections.Generic;
using System.Linq;
using ShiftAssist.Service;


namespace ShiftAssist.Models
{
    /// <summary>
    /// Rule that worker must have a 24-hour day off each week averaged over a four-week period.
    /// </summary>
    class RuleWeeklyDayOff : Rule
    {
        public override string Description => "A 24-hour day off each week averaged over a four-week period is required.";


        public RuleWeeklyDayOff()
        {  }


        /// <summary>
        /// Check for violations of this rule based on shifts and time range.
        /// </summary>
        /// <param name="shifts"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt">Not used</param>
        /// <returns></returns>
        public override IList<Violation> CheckForViolations(List<Shift> shifts, DateTime start, DateTime end)
        {
            List<Violation> violations = new List<Violation>();
            List<Shift> orderedShifts;
            int sufficientBreakPeriods = 0;      //Number of sufficient break periods between shifts.

            if (start == default(DateTime) || end == default(DateTime))
                throw new ArgumentOutOfRangeException();

            if (shifts != null && shifts.Count > 0)
            {
                start = start.Date;         // Set time to 00:00
                end = start.AddDays(28);    // Set end to 4 weeks after start.
                orderedShifts = shifts.OrderBy(s => s.Start).ToList<Shift>();  // Order shifts by start date time.

                // Step through ordered shifts and inspect break periods between shifts.
                for (int i = 0; i < orderedShifts.Count(); i++)
                {
                    // If not last shift, compare end of current shift to start of next shift.
                    // If it is last shift, compare end of current shift to end datetime for time range.
                    if (i+1 < orderedShifts.Count())
                    {
                        if (orderedShifts[i + 1].Start.Ticks - orderedShifts[i].End.Ticks >= TimeSpan.TicksPerDay)
                            sufficientBreakPeriods++;
                    }
                    else
                    {
                        if (end.Ticks - orderedShifts[i].End.Ticks >= TimeSpan.TicksPerDay)
                            sufficientBreakPeriods++;
                    }
                }

                // If number of breaks is less than 4, create a violation.
                if (sufficientBreakPeriods < 4)
                    violations.Add(new Violation(this, shifts));
            }

            return violations;
        }
    }
}
