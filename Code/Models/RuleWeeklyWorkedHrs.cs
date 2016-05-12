using System;
using System.Collections.Generic;
using ShiftAssist.Service;


namespace ShiftAssist.Models
{
    /// <summary>
    /// Rule that worker must be limited to 80 hour/week averaged over a four-week period.
    /// </summary>
    class RuleWeeklyWorkedHrs : Rule
    {
        public override string Description => "A maximum of 80 hour/week is allowed, averaged over a four-week period";


        public RuleWeeklyWorkedHrs()
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
            TimeSpan timeInRange;

            if (start == default(DateTime) || end == default(DateTime))
                throw new ArgumentOutOfRangeException();

            if (shifts != null && shifts.Count > 0)
            {
                start = start.Date;         // Set time to 00:00
                end = start.AddDays(28);    // Set end to 4 weeks after start.

                timeInRange = ShiftTools.GetShiftTimeInRange(shifts, start, end);

                // If average per week is over 80 hrs, create a violation.
                if (timeInRange.Ticks / 4 > TimeSpan.TicksPerHour * 80)
                    violations.Add(new Violation(this, shifts));
            }

            return violations;
        }
    }
}
