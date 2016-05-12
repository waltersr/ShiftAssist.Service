using System;
using System.Collections.Generic;
using System.Linq;


namespace ShiftAssist.Models
{
    /// <summary>
    /// Violation of rule that worker's individual shift must not exceed 24 hours of continuous duty.
    /// </summary>
    class RuleIntraShiftHrs : Rule
    {
        public override string Description => "A shift must not exceed 24 hours of continuous duty.";


        public RuleIntraShiftHrs()
        {  }


        /// <summary>
        /// Check for violations of this rule based on shifts and time range.
        /// </summary>
        /// <param name="shifts"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        public override IList<Violation> CheckForViolations(List<Shift> shifts, DateTime start, DateTime end)
        {
            List<Violation> violations = new List<Violation>();

            if (start == default(DateTime) || end == default(DateTime))
                throw new ArgumentOutOfRangeException();

            if (shifts != null && shifts.Count > 0)
            {
                // Look at each shift and determine if any exceed 24 hrs that fall within time range to inspect.
                foreach (var shift in shifts.Where(s => s.Start <= end && s.End >= start))
                {
                    // If shift exceeds 24 hrs, create a violation.
                    if ((shift.End.Ticks - shift.Start.Ticks) > TimeSpan.TicksPerDay)
                        violations.Add(new Violation(this, new List<Shift>() { shift }));
                }
            }

            return violations;
        }
    }
}
